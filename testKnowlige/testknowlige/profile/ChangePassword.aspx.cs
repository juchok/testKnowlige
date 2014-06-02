using System;
using System.Web.Security;
using TestKnowlige.classes;

namespace TestKnowlige.login
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            menu.ActiveItem(5);
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            if (LoGiN.CheckUser(User.Identity.Name, txtOldPass.Text)
                && LoGiN.UpdatePass(txtNewPass.Text, User.Identity.Name))
            {
                FormsAuthentication.RedirectFromLoginPage(User.Identity.Name, true);
            }
            else {
                errorPas.Visible = true;
            }
                
        }               
    }
}