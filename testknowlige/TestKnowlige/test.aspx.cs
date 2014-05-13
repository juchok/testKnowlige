using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;
using System.Net;
using System.Text;
using System.IO;

namespace TestKnowlige
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"])) {
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
                string str = "select TOP(1) t.name, c.categories_name, d.discipline_name from test_question as ts "+
                    " inner join test as t on ts.test_id = t.test_id " +
                    " inner join question as q on q.question_id = ts.question_id " +                    
                    " inner join categories as c on c.cat_id = q.cat_id " +
                    " inner join discipline as d on d.discipline_id = c.discipline_id " +
                    " where t.test_id = @id";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("id",Request.QueryString["id"]);
                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();                        
                        header_discipline.Text = "Дисциплина: " + dr["discipline_name"].ToString();
                        
                        header_categories.Text = "Категория: " + dr["categories_name"].ToString();
                        header_test.Text = "Тест: " + dr["name"].ToString();
                    }
                }
                catch (Exception)
                {                    
                    throw;
                }
                
                













                
                str = "select q.text, t.question_id from question as q inner join test_question as t on q.question_id = t.question_id " +
                    " where t.test_id = @id";
                SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
                ds.SelectParameters.Add("id", Request.QueryString["id"]);
                questions.DataSource = ds;                
                questions.DataBind();

                int i = 0;
                foreach (RepeaterItem item in questions.Items)
                {
                    Repeater answer = (Repeater)questions.Items[i].FindControl("answers");
                    string id = (item.FindControl("question_id") as HiddenField).Value;
                    str = "select answer_text from answer where question_id = @id";
                    SqlDataSource ds1 = new SqlDataSource(con.ConnectionString, str);
                    ds1.SelectParameters.Add("id", id);
                    answer.DataSource = ds1;
                    answer.DataBind();
                    i++;
                }
                
                
                //(Page.FindControl("answer") as Repeater).DataSource = ds1;
                
            }
             else {
//                 Response.Redirect("~/default.aspx");
            }
        }

        protected void Complite_Click(object sender, EventArgs e)
        {
            
        }
       
    }
}