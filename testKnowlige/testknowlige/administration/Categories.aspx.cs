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
    }
}