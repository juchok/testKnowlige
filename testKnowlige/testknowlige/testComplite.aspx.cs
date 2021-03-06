﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using TestKnowlige.classes;
namespace TestKnowlige
{
    public partial class testComplite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            float test_points = 0;
                        
            if (PreviousPage == null) {
                Response.Redirect("~/default.aspx");
            }            
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
                Label point = new Label();
                point.Text = (question.FindControl("question_points") as HiddenField).Value + " баллов";
                point.CssClass = "points";
                lb.Controls.Add(point);
                Page.FindControl("bodyAnswers").Controls.Add(lb);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", id);
                float points = 0;
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
                                if (cb.Checked || cb.ForeColor != System.Drawing.Color.Empty) {
                                    if (bool.Parse(dr["correct"].ToString()) && cb.Checked)
                                        points += testComplit.PointsToAnswer(id, (question.FindControl("question_points") as HiddenField).Value, true);
                                    else
                                    {
                                        if (bool.Parse(dr["correct"].ToString()) && !cb.Checked)
                                            points -= testComplit.PointsToAnswer(id, (question.FindControl("question_points") as HiddenField).Value, true);
                                        else 
                                            points += testComplit.PointsToAnswer(id, (question.FindControl("question_points") as HiddenField).Value, false);
                                    }
                                }
                            }
                        }                       
                    }
                    if (points < 0)
                        points = 0;
                    Label your_question_point = new Label();
                    your_question_point.Text = "Ваши балы за вопрос: " + Math.Ceiling(points) + " баллов";
                    your_question_point.CssClass = "pointToQuestion";
                    Page.FindControl("bodyAnswers").Controls.Add(your_question_point);
                    test_points += points;
                }
                catch (Exception ex)
                {
                    MessageError.Text = ex.Message;
                    MessageError.Visible = true;
                }
                finally {
                    con.Close();
                }

            }

            Label test_point = new Label();
            test_point.Text = "Ваши баллы за тест: " + test_points + " баллов";
            test_point.CssClass = "test_points";
            Page.FindControl("bodyAnswers").Controls.Add(test_point);
                        
            try
            {
                Test.SaveTestComplite(User.Identity.Name, (PreviousPage.FindControl("tests").FindControl("test_id") as HiddenField).Value, test_points);
            }
            catch (Exception ex)
            {
                MessageError.Text = ex.Message;
                MessageError.Visible = true;
            }
            finally {
                con.Close();
            }
        }

        internal static void Show(GridView ListTests, string UserName)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select d.Discipline_name, c.categories_name, t.name, ct.points, ct.dateComplite " +
                " from Complite_test as ct inner join test as t on ct.test_id = t.test_id " +
                " inner join Categories as c on c.cat_id = t.cat_id " + 
                " inner join discipline as d on d.discipline_id = c.discipline_id " +
                " inner join users as u on u.user_id = ct.user_id where u.login = @login";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("login", UserName);
            try
            {
                con.Open();
                SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
                Parameter p = new Parameter("login", System.Data.DbType.String, UserName);                
                ds.SelectParameters.Add(p);
                ListTests.DataSource = ds;
                ListTests.DataBind();
            }
            catch (Exception)
            {
                throw new ApplicationException("Не удается отобразить список завершенных тестов");
            }
            finally {
                con.Close();
            }
        }
    }
}