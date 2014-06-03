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

            MessageError.Visible = false;
            menu.ActiveItem(3);
            try
            {
                testComplite.Show(ListTests, User.Identity.Name);
            }
            catch (Exception ex) {
                MessageError.Text = ex.Message;
                MessageError.Visible = true;
            }
        }
    }
}