using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestKnowlige.classes;
using System.Web.Security;

namespace TestKnowlige.administration
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserListRefresh();
            }
            MessageError.Visible = false;
            AdminMenu.ActiveItem(6);            
        }

        protected void UserList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            UserList.EditIndex = e.NewEditIndex;
            UserListRefresh();

            GridViewRow row = UserList.Rows[e.NewEditIndex];
            (row.Cells[6].FindControl("UserCatigories") as DropDownList).DataSource = Roles.GetAllRoles();
            string[] st = Roles.GetRolesForUser((row.Cells[3].Controls[0] as TextBox).Text);
            if(st.Length > 0)            
                (row.Cells[6].FindControl("UserCatigories") as DropDownList).SelectedValue = Roles.GetRolesForUser((row.Cells[3].Controls[0] as TextBox).Text)[0];;
            (row.Cells[6].FindControl("UserCatigories") as DropDownList).DataBind();
        }

        private void UserListRefresh()
        {
            UserList.DataSource = Administraion.UserList();
            UserList.DataBind();
        }

        protected void UserList_RowCancelEditing(object sender, GridViewCancelEditEventArgs e)
        {
            UserList.EditIndex = -1;
            UserListRefresh();
        }

        protected void UserList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = UserList.Rows[e.RowIndex];
            
            UserInfo info = new UserInfo();
            info.FirstName = (row.Cells[1].Controls[0] as TextBox).Text;
            info.LastName = (row.Cells[2].Controls[0] as TextBox).Text;
            info.Login = (row.Cells[3].Controls[0] as TextBox).Text;
            info.Question = (row.Cells[4].Controls[0] as TextBox).Text;
            info.Answer = (row.Cells[5].Controls[0] as TextBox).Text;
            info.Categories = (row.Cells[6].FindControl("UserCatigories") as DropDownList).SelectedValue;
            info.UserId = int.Parse((row.Cells[6].FindControl("UserId") as Label).Text);
            try
            {
                Administraion.UpdateUser(info);
            }
            catch (Exception ex) {
                MessageError.Text = ex.Message;
                MessageError.Visible = true;
            }

            UserList_RowCancelEditing(sender, new GridViewCancelEditEventArgs(e.RowIndex));
        }

        protected void UserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TableRow row = UserList.Rows[e.RowIndex];
            try
            {
                Administraion.deleteUser(row.Cells[3].Text);
            }
            catch (Exception ex) {
                MessageError.Text = ex.Message;
                MessageError.Visible = true;
            }

            UserListRefresh();
        }        
    }
}