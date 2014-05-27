using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using TestKnowlige.classes;

namespace TestKnowlige.profile
{
    public partial class yourTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select t.test_id, t.name, cat.categories_name, d.discipline_name from test as t inner join categories as cat on cat.cat_id = t.cat_id "
                + " inner join discipline as d on d.discipline_id = cat.discipline_id "
                + " where t.user_id = @id";
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            ds.SelectParameters.Add("id", LoGiN.UserId(User.Identity.Name).ToString());            
            listTest.DataSource = ds;
            listTest.DataBind();

            menu.ActiveItem(7);
        }
    }
}