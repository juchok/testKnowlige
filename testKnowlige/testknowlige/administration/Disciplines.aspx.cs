using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestKnowlige.classes;
using System.Data;

namespace TestKnowlige.administration
{
    public partial class Disciplines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                RefreshDisciplineList();
            }
            MessageError.Visible = false;
        }

        protected void Disciplinelist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DisciplineList.EditIndex = e.NewEditIndex;
            RefreshDisciplineList();
        }

        protected void Disciplinelist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = DisciplineList.Rows[e.RowIndex];
                if (string.IsNullOrEmpty((row.Cells[1].FindControl("editDiscipline") as TextBox).Text)
                    || (row.Cells[1].FindControl("editDiscipline") as TextBox).Text.Length < 3)
                    throw new ApplicationException("Поле имя дисциплины не может быть пустым или меньше 3 символов");
                Administraion.UpdateDisciplineName(e.RowIndex, (row.Cells[1].FindControl("editDiscipline") as TextBox).Text);
                DisciplineList.EditIndex = -1;
                RefreshDisciplineList();
            }
            catch (Exception ex)
            {
                MessageError.Text = ex.Message;
                MessageError.Visible = true;
            }      
            
        }

        protected void Disciplinelist_RowCancelEditing(object sender, GridViewCancelEditEventArgs e)
        {
            DisciplineList.EditIndex = -1;
            RefreshDisciplineList();
        }

        protected void RefreshDisciplineList()
        {
            DisciplineList.DataSource = Administraion.DisciplineList();
            DisciplineList.DataBind();
            AdminMenu.ActiveItem(3);
        }

        protected void Disciplinelist_RowDeleting(object sender, GridViewDeleteEventArgs e) 
        {
            try
            {
                GridViewRow row = DisciplineList.Rows[e.RowIndex];
                if (!Administraion.deleteDiscipline((row.Cells[1].FindControl("ItemName") as Label).Text))
                {
                    MessageError.Text = "Не удалось удалить дисциплину";
                    MessageError.Visible = true;
                }
            }
            catch (Exception ex) {
                MessageError.Text = ex.Message;
                MessageError.Visible = true;
            }
            RefreshDisciplineList();
        }

        protected void Disciplinelist_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
            if (e.CommandName.Equals("Insert"))
            {
                try
                {
                    GridViewRow row = DisciplineList.FooterRow;
                    if (string.IsNullOrEmpty((row.Cells[1].FindControl("newDiscipline") as TextBox).Text)
                        || (row.Cells[1].FindControl("newDiscipline") as TextBox).Text.Length < 3)
                                throw new ApplicationException("Поле имя дисциплины не может быть пустым или меньше 3 символов");
                    
                    
                }
                catch (Exception ex)
                {
                    MessageError.Text = ex.Message;
                    MessageError.Visible = true;
                }
                RefreshDisciplineList();
            }
        }
    }
}