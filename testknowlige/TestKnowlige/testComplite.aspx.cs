using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TestKnowlige
{
    public partial class testComplite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //string st = (PreviousPage.FindControl("questions").FindControl("answer") as CheckBox).Checked.ToString(); ;
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select * from answer where question_id = @id", st1;
            bool? st = null;
            SqlCommand cmd = new SqlCommand(str, con);

             
            header_discipline.Text = (PreviousPage.FindControl("tests").FindControl("header_discipline") as Label).Text;
            header_categories.Text = (PreviousPage.FindControl("tests").FindControl("header_categories") as Label).Text;
            header_test.Text = (PreviousPage.FindControl("tests").FindControl("header_test") as Label).Text;

            foreach (RepeaterItem question in PreviousPage.FindControl("questions").Controls)
            {
                string id = (question.FindControl("question_id") as HiddenField).Value.ToString();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", id);
                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows) { 
                        while(dr.Read()){
                            Label lb = new Label();
                            lb.Text = dr["answer_text"].ToString();                            
                            st = null;
                            string s1, s2;
                            s1 = dr["answer_text"].ToString();
                            bool s3 = bool.Parse(dr["correct"].ToString());
                            foreach (RepeaterItem answer in question.FindControl("answers").Controls)
                            {
                                if (s1 == (answer.FindControl("answer") as CheckBox).Text)
                                {
                                    if (s3.ToString() == (answer.FindControl("answer") as CheckBox).Checked.ToString())
                                    {
                                        if ((answer.FindControl("answer") as CheckBox).Checked)
                                            st = true;
                                    }
                                    else {
                                        st = false;
                                    }
                                    break;
                                }                                
                            }
                            if (st != null)
                            {
                                if (st.Value == true)
                                {
                                    st1 = "выбран один из правильных ответов";
                                    lb.ForeColor = System.Drawing.Color.Green;
                                }
                                else                             
                                {
                                    st1 = "допущена ответ пропущен";
                                    lb.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            else{
                                st1 = "правильно что не выбрали";
                            }                                                         
                            
                            Page.FindControl("testComplite").Controls.Add(lb);
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