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
        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in waitUserslist.Controls)
	        {
                if ((item.FindControl("login") as CheckBox).Checked) 
                {
                    Administraion.AddAdmin((item.FindControl("login") as CheckBox).Text);
                    RefreshWaitList();
                }
	        }
                
        }

        protected void DeleteUser_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in waitUserslist.Controls)
            {
                if ((item.FindControl("login") as CheckBox).Checked)
                {
                    Administraion.DeleteWaitUser((item.FindControl("login") as CheckBox).Text);
                    RefreshWaitList();
                }
            }

        }

        private void RefreshWaitList()
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
    }
}