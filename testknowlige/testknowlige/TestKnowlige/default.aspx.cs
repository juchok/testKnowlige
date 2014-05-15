using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using TestKnowlige.classes;

namespace TestKnowlige
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!SelectItem.Discipline(DirDiscipline, "select discipline_name from discipline"))            
            {
                errDis.Visible = true;
            }

            string str = SelectItem.Categories(DirCategories, Request.QueryString["Discipline"]).ToString();

            if (string.IsNullOrEmpty(str)) {
                SelectDiscipline.Visible = true;
            }
            if (str.ToLower()=="false")
            {
                errCat.Visible = true;
            }

            str = SelectItem.Tests(DirTests, Request.QueryString["categories"]).ToString();

            if (string.IsNullOrEmpty(str)) {
                selectCategories.Visible = true;
            }
            if (str.ToLower() == "false")
            {
                errTests.Visible = true;
            }
            
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                lnkChangePass.Visible = true;
            }
            
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            
        }
    }
}