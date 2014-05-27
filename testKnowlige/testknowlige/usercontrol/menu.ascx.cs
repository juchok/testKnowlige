using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace TestKnowlige.usercontrol
{
    public partial class menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Roles.IsUserInRole(Page.User.Identity.Name, "Teacher")) {
                yourtests.Visible = false;
            }
            if (!Roles.IsUserInRole(Page.User.Identity.Name, "Admin")) {
                administration.Visible = false;
            }
        }
                
        public void ActiveItem(int i) {
            switch (i)
            {
                case 1:                    
                    common.CssClass = "active";
                    break;
                case 2:
                    more.CssClass = "active";
                    break;
                case 3:
                    test.CssClass = "active";
                    break;
                case 4:
                    message.CssClass = "active";
                    break;
                case 5:
                    ChangePassword.CssClass = "active";
                    break;
                case 6:
                    admins.CssClass = "active";
                    break;
                case 7:
                    yourtests.CssClass = "active";
                    break;
                case 8:
                    administration.CssClass = "active";
                    break;
                default:
                    break;
            }
        }
    }
}