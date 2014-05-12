using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TestKnowlige
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"])) {
                string con =WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                string str = "select q.text, t.question_id from question as q inner join test_question as t on q.question_id = t.question_id " +
                    " where t.test_id = @id";
                SqlDataSource ds = new SqlDataSource(con, str);
                ds.SelectParameters.Add("id", Request.QueryString["id"]);
                questions.DataSource = ds;                
                questions.DataBind();

                int i = 0;
                foreach (RepeaterItem item in questions.Items)
                {
                    Repeater answer = (Repeater)questions.Items[i].FindControl("answers");
                    string id = (item.FindControl("question_id") as HiddenField).Value;
                    str = "select answer_text from answer where question_id = @id";
                    SqlDataSource ds1 = new SqlDataSource(con, str);
                    ds1.SelectParameters.Add("id", id);
                    answer.DataSource = ds1;
                    answer.DataBind();
                    i++;
                }
                
                //(Page.FindControl("answer") as Repeater).DataSource = ds1;
                
            }
        }
    }
}