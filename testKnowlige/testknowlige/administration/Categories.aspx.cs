using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestKnowlige.classes;

namespace TestKnowlige.administration
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AdminMenu.ActiveItem(4);
                RefreshCategories();
            }
            MessageError.Visible = false;
        }

        private void RefreshCategories()
        {
            CategoriesList.DataSource = Administraion.CategoriesList();
            CategoriesList.DataBind();
        }

        protected void CategoriesList_RowEditing(object sender, GridViewEditEventArgs e)
        {               
            GridViewRow trow = CategoriesList.Rows[e.NewEditIndex];
            string disc = (trow.Cells[1].FindControl("lblDiscipline_name") as Label).Text;
            CategoriesList.EditIndex = e.NewEditIndex;            
            RefreshCategories();
            GridViewRow row = CategoriesList.Rows[e.NewEditIndex];
            (row.Cells[1].FindControl("ddDiscipline") as DropDownList).DataSource = Administraion.DisciplineList();
            (row.Cells[1].FindControl("ddDiscipline") as DropDownList).DataBind();
            (row.Cells[1].FindControl("ddDiscipline") as DropDownList).SelectedValue = disc;            
        }

        protected void CategoriesList_RowCancelEditing(object sender, GridViewCancelEditEventArgs e)
        {
            CategoriesList.EditIndex = -1;
            RefreshCategories();
        }

        protected void CategoriesList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = CategoriesList.Rows[e.RowIndex];
            string disc = (row.Cells[1].FindControl("ddDiscipline") as DropDownList).SelectedValue;
            string cat_name = (row.Cells[2].Controls[0] as TextBox).Text;
            try
            {
                int cat_old_id = Administraion.CategoriesID(e.RowIndex);
                Administraion.UpdateCategories(disc, cat_name, cat_old_id);

            }
            catch (Exception ex) {
                MessageError.Text = ex.Message;
                MessageError.Visible = true;
            }
            CategoriesList.EditIndex = -1;
            RefreshCategories();
        }
        
        protected void CategoriesList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TableRow row = CategoriesList.Rows[e.RowIndex];
            if (!Administraion.deleteCategories(row.Cells[2].Text))
            {
                MessageError.Text = "Не удалось удалить дисциплину";
                MessageError.Visible = true;
            }
            RefreshCategories();
        }
    }
}