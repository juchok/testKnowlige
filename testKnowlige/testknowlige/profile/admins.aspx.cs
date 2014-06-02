using System;
using System.Web.UI.WebControls;
using TestKnowlige.classes;

namespace TestKnowlige.profile
{
    public partial class admins : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            menu.ActiveItem(6);
            listAdmins.DataSource = Administraion.AdminsList();
            listAdmins.DataBind();

        }

        protected void writeMessage_Click(object sender, EventArgs e) 
        {            
            MailMessage.ToUsers = (sender as Button).CommandArgument;
            MailMessage.FromUser = User.Identity.Name;
            MailMessage.EnableFrom = false;
            MailMessage.Visible = true;
        }
    }
}