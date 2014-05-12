using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Principal;

namespace TestKnowlige
{
    public partial class Discipline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Page.User.IsInRole("Teacher"))
            //    Label1.Text = HttpContext.Current.User.Identity.Name + " is teacher";
            //else
            //    Label1.Text = HttpContext.Current.User.Identity.Name + " is students";
        }
    }
}