using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.UI;

namespace TestKnowlige.classes
{
    public class testComplit
    {
        public static void FindQuestion(ControlCollection collection, int id) { 
            
        }


        public static bool? CheckAnswer(CheckBox cb, string DataAnswerText, bool DataAnswerCorrect) {     
                if (DataAnswerCorrect && cb.Checked)
                {
                    return true;
                }
                
                if(DataAnswerCorrect && !cb.Checked || !DataAnswerCorrect && cb.Checked)
                {
                    return false;
                }                
            
            return null;
        }

        public static CheckBox FindAnswer(string DataAnswerText, bool DataAnswerCurrent, ControlCollection collection) {
            foreach (RepeaterItem item in collection)
            {
                if ((item.FindControl("answer") as CheckBox).Text == DataAnswerText) {
                    CheckBox cb = new CheckBox();
                    cb = (item.FindControl("answer") as CheckBox);
                    cb.ForeColor = ColorAnswer(CheckAnswer(cb, DataAnswerText, DataAnswerCurrent));
                    cb.Enabled = false;
                    cb.CssClass = "answer";
                    return cb;
                }
            }
            return null;
        }



        public static System.Drawing.Color ColorAnswer(bool? bl) {
            if (bl == null) {
                return System.Drawing.Color.Empty;
            }
            if (bl.Value) {
                return System.Drawing.Color.Green;
            }
            if (!bl.Value) {
                return System.Drawing.Color.Red;
            }
            return System.Drawing.Color.Empty;
        }

        public static float PointsToAnswer(string question_id, string question_points, bool correct) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);            
            string str_answer = "select COUNT(*) from answer where question_id = @id and correct = @cor";                        
            SqlCommand cmd_answer = new SqlCommand(str_answer, con);
            cmd_answer.Parameters.AddWithValue("id", question_id);
            cmd_answer.Parameters.AddWithValue("cor", correct);
            try
            {
                con.Open();                
                float ans = float.Parse(((int)cmd_answer.ExecuteScalar()).ToString());
                if (correct)
                {
                    return float.Parse(question_points) / ans;
                }
                else {
                    return -float.Parse(question_points) / ans;
                }
                
            }
            catch (Exception)
            {
                return 0;
            }
            finally {
                con.Close();
            }            
        }
        
    }
}