using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using TestKnowlige.classes;

namespace TestKnowlige.login
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (LoGiN.CheckUser(txtLogin.Text, txtPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtLogin.Text, true);
            }
            else {
                ErrorMessage.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}