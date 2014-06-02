using System;
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
            CategoriesList.DataSource = Categorieses.CategoriesList();
            CategoriesList.DataBind();
            Discipliness.DisciplineList((CategoriesList.FooterRow.FindControl("DisciplineList") as DropDownList));
            (CategoriesList.FooterRow.FindControl("DisciplineList") as DropDownList).DataBind();
            AdminMenu.ActiveItem(4);
        }

        protected void CategoriesList_RowEditing(object sender, GridViewEditEventArgs e)
        {               
            GridViewRow trow = CategoriesList.Rows[e.NewEditIndex];
            string disc = (trow.Cells[1].FindControl("lblDiscipline_name") as Label).Text;
            CategoriesList.EditIndex = e.NewEditIndex;            
            RefreshCategories();
            GridViewRow row = CategoriesList.Rows[e.NewEditIndex];
            (row.Cells[1].FindControl("ddDiscipline") as DropDownList).DataSource = TestKnowlige.classes.Discipliness.DisciplineList();
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
            string cat_name = (row.Cells[2].FindControl("EditCaategories") as TextBox).Text;
            try
            {
                int cat_old_id = Categorieses.CategoriesID(e.RowIndex);
                Categorieses.UpdateCategories(disc, cat_name, cat_old_id);

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
            if (!Categorieses.deleteCategories((row.Cells[2].FindControl("CatName") as Label).Text))
            {
                MessageError.Text = "Не удалось удалить категорию";
                MessageError.Visible = true;
            }
            RefreshCategories();
        }

        protected void CategoriesList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                try
                {
                    GridViewRow row = CategoriesList.FooterRow;
                    if (string.IsNullOrEmpty((row.Cells[1].FindControl("newCategories") as TextBox).Text)
                        || (row.Cells[1].FindControl("newCategories") as TextBox).Text.Length < 3)
                        throw new ApplicationException("Поле имя категории не может быть пустым или меньше 3 символов");

                    Categorieses.NewCategories((row.Cells[1].FindControl("newCategories") as TextBox).Text,
                         Discipliness.DisciplineId((CategoriesList.FooterRow.FindControl("DisciplineList") as DropDownList).SelectedValue), 
                         User.Identity.Name);                         
                }
                catch (Exception ex)
                {
                    MessageError.Text = ex.Message;
                    MessageError.Visible = true;
                }
                RefreshCategories();
            }
        }
    }
}