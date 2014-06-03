using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestKnowlige.classes;

namespace TestKnowlige.administration
{
    public partial class Tests : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                RefreshTest();
            }
            MessageError.Visible = false;
        }

        private void RefreshTest() {
            TestList.DataSource = Test.TestList();
            TestList.DataBind();
            AdminMenu.ActiveItem(5);
        }

        protected void TestList_RowEditing(object sender, GridViewEditEventArgs e) {            
            GridViewRow trow = TestList.Rows[e.NewEditIndex];
            string dis_name = (trow.Cells[1].FindControl("lblDiscipline_name") as Label).Text;
            string cat_name = (trow.Cells[2].FindControl("lblDiscipline_name") as Label).Text;
            TestList.EditIndex = e.NewEditIndex;
            RefreshTest();
            GridViewRow row = TestList.Rows[e.NewEditIndex];
            (row.Cells[1].FindControl("ddDiscipline") as DropDownList).DataSource = Discipliness.DisciplineListHasCategories();
            (row.Cells[1].FindControl("ddDiscipline") as DropDownList).DataBind();
            (row.Cells[1].FindControl("ddDiscipline") as DropDownList).SelectedValue = dis_name;
            (row.Cells[2].FindControl("ddCategories") as DropDownList).DataSource = Categorieses.CategoriesList(dis_name);
            (row.Cells[2].FindControl("ddCategories") as DropDownList).DataBind();
            (row.Cells[2].FindControl("ddCategories") as DropDownList).SelectedValue = dis_name;
        }

        protected void ddDiscipline_ChangeIndex(object sender, EventArgs e) 
        {
            ((sender as DropDownList).Parent.FindControl("ddCategories") as DropDownList).DataSource = Categorieses.CategoriesList((sender as DropDownList).SelectedValue);
            ((sender as DropDownList).Parent.FindControl("ddCategories") as DropDownList).DataBind();
        }

        protected void TestList_CancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            TestList.EditIndex = -1;
            RefreshTest();
        }

        protected void TestList_UpdatingRow(object sender, GridViewUpdateEventArgs e) {
            string Select_Discipline = ((sender as GridView).Rows[e.RowIndex].Cells[1].FindControl("ddDiscipline") as DropDownList).SelectedValue;
            string Select_Categories = ((sender as GridView).Rows[e.RowIndex].Cells[2].FindControl("ddCategories") as DropDownList).SelectedValue;
            string test_name = ((sender as GridView).Rows[e.RowIndex].Cells[3].FindControl("TestName") as TextBox).Text;
            string test_id = ((sender as GridView).Rows[e.RowIndex].Cells[4].FindControl("TestEditLink") as HyperLink).NavigateUrl.Split('=')[1];
            try
            {
                Test.UpdateTest(test_id, test_name, Select_Categories);
            }
            catch (Exception ex) {
                MessageError.Text = ex.Message;
                MessageError.Visible = true;
            }
            TestList.EditIndex = -1;
            RefreshTest();
        }

        protected void TestList_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            string test_id = ((sender as GridView).Rows[e.RowIndex].Cells[4].FindControl("TestEditLink") as HyperLink).NavigateUrl.Split('=')[1];
            try
            {
                Test.DeleteTest(test_id);
            }
            catch (Exception ex)
            {
                MessageError.Text = ex.Message;
                MessageError.Visible = true;
            }
        }
    }
}