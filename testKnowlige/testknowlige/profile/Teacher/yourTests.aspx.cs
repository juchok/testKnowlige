using System;
using TestKnowlige.classes;

namespace TestKnowlige.profile
{
    public partial class yourTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listTest.DataSource = Test.YourTests(User.Identity.Name);
            listTest.DataBind();
            menu.ActiveItem(7);
        }
    }
}