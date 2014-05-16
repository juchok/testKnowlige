using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using TestKnowlige.classes;

namespace TestKnowlige.login
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            if (LoGiN.CheckUser(User.Identity.Name, txtOldPass.Text)
                && UpdatePassword.update(txtNewPass.Text, User.Identity.Name))
            {
                FormsAuthentication.RedirectFromLoginPage(User.Identity.Name, true);
            }
            else {
                errorPas.Visible = true;
            }
                
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtNewPass.Text = txtNewRePass.Text = "";
            Response.Redirect("~/default.aspx");
        }
    }
}