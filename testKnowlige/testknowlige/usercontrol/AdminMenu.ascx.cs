using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace TestKnowlige.usercontrol
{
    public partial class AdminMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
                
        public void ActiveItem(int i) {
            switch (i)
            {
                case 1:
                    Home.CssClass = "active";
                    break;
                case 2:
                    common.CssClass = "active";
                    break;
                case 3:
                    discipline.CssClass = "active";
                    break;
                case 4:
                    categories.CssClass = "active";
                    break;
                case 5:
                    questions.CssClass = "active";
                    break;
                case 6:
                    test.CssClass = "active";
                    break;
                case 7:
                    users.CssClass = "active";
                    break;
                case 8:
                    newAdmin.CssClass = "active";
                    break;
                default:
                    break;
            }
        }
    }
}