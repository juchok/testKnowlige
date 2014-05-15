using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Web.Configuration;
using TestKnowlige.classes;
namespace TestKnowlige
{
    public partial class testComplite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage == null) {
                Response.Redirect("~/default.aspx");
            }
            //string st = (PreviousPage.FindControl("questions").FindControl("answer") as CheckBox).Checked.ToString(); ;
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select * from answer where question_id = @id";            
            SqlCommand cmd = new SqlCommand(str, con);
             
            header_discipline.Text = (PreviousPage.FindControl("tests").FindControl("header_discipline") as Label).Text;
            header_categories.Text = (PreviousPage.FindControl("tests").FindControl("header_categories") as Label).Text;
            header_test.Text = (PreviousPage.FindControl("tests").FindControl("header_test") as Label).Text;

            foreach (RepeaterItem question in PreviousPage.FindControl("questions").Controls)
            {
                string id = (question.FindControl("question_id") as HiddenField).Value.ToString();
                Label lb = new Label();
                lb = (question.FindControl("question") as Label);
                lb.CssClass = "question";
                Page.FindControl("bodyAnswers").Controls.Add(lb);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", id);
                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows) { 
                        while(dr.Read()){
                            CheckBox cb = testComplit.FindAnswer(dr["answer_text"].ToString(), bool.Parse(dr["correct"].ToString()), question.FindControl("answers").Controls);
                            if (cb != null)
                            {
                                Page.FindControl("bodyAnswers").Controls.Add(cb);
                            }
                        }                       
                    }                        
                }
                catch (Exception)
                {
                    throw;
                }
                finally {
                    con.Close();
                }

            }
        }
    }
}