using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using TestKnowlige.classes;

namespace TestKnowlige.administration
{
    public partial class WaitUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminMenu.ActiveItem(8);
            if (!Page.IsPostBack)
            {
                RefreshWaitList();
            }
            MessageError.Visible = false;
        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem item in waitUserslist.Controls)
                {
                    if ((item.FindControl("login") as CheckBox).Checked)
                    {
                        Administraion.AddAdmin((item.FindControl("login") as CheckBox).Text);
                    }
                }
            }
            catch (Exception ex) {
                MessageError.Text = ex.Message;
                MessageError.Visible = true;
            }
            RefreshWaitList();                
        }

        protected void DeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem item in waitUserslist.Controls)
                {
                    if ((item.FindControl("login") as CheckBox).Checked)
                    {
                        Administraion.DeleteWaitUser((item.FindControl("login") as CheckBox).Text);
                    }
                }
            }
            catch (Exception ex) {
                MessageError.Text = ex.Message;
                MessageError.Visible = true;
            }
            RefreshWaitList();
        }

        private void RefreshWaitList()
        {
            try
            {
                SqlDataSource ds = Administraion.waitUserList();
                if (ds == null)
                {
                    MessageForAdmin.Text = "Нет записей";
                    MessageForAdmin.Visible = true;
                    waitUserslist.Visible = false;
                }
                else
                {
                    waitUserslist.DataSource = ds;
                    waitUserslist.DataBind();
                }
            }
            catch (Exception ex) {
                MessageError.Text = ex.Message;
                MessageError.Visible = true;
            }
        }
    }
}