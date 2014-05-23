using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestKnowlige.usercontrol
{
    public partial class menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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