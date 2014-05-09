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
            if (SelectItem.Count("select discipline_name from discipline"))
            {
                SelectItem.Discipline(DirDiscipline);
                if (!string.IsNullOrEmpty(Request.QueryString["discipline"]))
                    categories_header.Text = Request.QueryString["discipline"];
                else { 
                }
            }
            else
            {
                errDis.Visible = true;
            }

            if (!SelectItem.DefaultCategories(DirCategories))
                errCat.Visible = true;



            if (HttpContext.Current.User.Identity.IsAuthenticated)
                lnkChangePass.Visible = true;
        }
    }
}