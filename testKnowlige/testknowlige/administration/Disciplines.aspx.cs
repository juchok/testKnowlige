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
            
        }

        protected void Disciplinelist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DisciplineList.EditIndex = e.NewEditIndex;
            RefreshDisciplineList();
            GridViewRow row = DisciplineList.Rows[e.NewEditIndex];
            string st = (row.Cells[1].Controls[0] as TextBox).Text;

        }

        protected void Disciplinelist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {                                          
            GridViewRow row = DisciplineList.Rows[e.RowIndex];
            Administraion.UpdateDisciplineName(e.RowIndex, ((TextBox)(row.Cells[1].Controls[0])).Text);
            DisciplineList.EditIndex = -1;
            RefreshDisciplineList();
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
        }

        protected void Disciplinelist_RowDeleting(object sender, GridViewDeleteEventArgs e) 
        {
            TableRow row = DisciplineList.Rows[e.RowIndex];                        
            if (!Administraion.deleteDiscipline(row.Cells[1].Text))
            {
                MessageError.Text = "Не удалось удалить дисциплину";
                MessageError.Visible = true;
            }
            RefreshDisciplineList();
        }
    }
}