using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            TestList.DataSource = Administraion.TestList();
            TestList.DataBind();
        }

        protected void TestList_RowEditing(object sender, GridViewEditEventArgs e) {
            GridViewRow trow = TestList.Rows[e.NewEditIndex];
            string dis_name = (trow.Cells[1].FindControl("lblDiscipline_name") as Label).Text;
            string cat_name = (trow.Cells[2].FindControl("lblDiscipline_name") as Label).Text;
            TestList.EditIndex = e.NewEditIndex;
            RefreshTest();
            GridViewRow row = TestList.Rows[e.NewEditIndex];
            (row.Cells[1].FindControl("ddDiscipline") as DropDownList).DataSource = Administraion.DisciplineList();
            (row.Cells[1].FindControl("ddDiscipline") as DropDownList).DataBind();
            (row.Cells[1].FindControl("ddDiscipline") as DropDownList).SelectedValue = dis_name;
            (row.Cells[2].FindControl("ddCategories") as DropDownList).DataSource = Administraion.CategoriesList(dis_name);
            (row.Cells[2].FindControl("ddCategories") as DropDownList).DataBind();
            (row.Cells[2].FindControl("ddCategories") as DropDownList).SelectedValue = dis_name;
        }

        protected void ddDiscipline_ChangeIndex(object sender, EventArgs e) 
        { 
        }
    }
}