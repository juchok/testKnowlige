using System;

namespace TestKnowlige.profile
{
    public partial class Tests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(User.Identity.Name)) {
                Response.Redirect("~/default.aspx");
            }
            menu.ActiveItem(3);
            testComplite.Show(ListTests, User.Identity.Name);
        }
    }
}