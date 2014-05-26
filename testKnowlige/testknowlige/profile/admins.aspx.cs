using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace TestKnowlige.profile
{
    public partial class admins : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            menu.ActiveItem(6);
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select firstname, lastname, login from users where categories='admin'";
/* ----- Сделать проверку если нет списка --------*/
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            listAdmins.DataSource = ds;
            listAdmins.DataBind();
            sendMessage.Visible = true;            
        }

        protected void writeMessage_Click(object sender, EventArgs e) 
        {            
            MailMessage.ToUsers = (sender as Button).CommandArgument;
            MailMessage.FromUser = "qweqwe";
            MailMessage.EnableFrom = false;
            MailMessage.Visible = true;
        }
    }
}