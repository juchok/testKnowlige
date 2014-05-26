﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TestKnowlige.classes
{
    public class Test
    {
        public static int AddTestId(string name) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select test_id from temptest where name = @name";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("name", name);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) {
                    dr.Read();
                    return int.Parse(dr["test_id"].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }            
            finally {
                con.Close();
            }
            return 0;
        }

        public static void AnswerBind(Page page) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

            string str = "select text, points, question_id from tempquestions where test_id = @id";
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            ds.SelectParameters.Add("id", (page.FindControl("test_id") as HiddenField).Value);

            (page.FindControl("questions") as Repeater).DataSource = ds;
            (page.FindControl("questions") as Repeater).DataBind();


            foreach (RepeaterItem item in (page.FindControl("questions") as Repeater).Items)
            {
                string id = (item.FindControl("question_id") as HiddenField).Value;
                str = "select * from tempanswer where question_id = @id";
                SqlDataSource ds1 = new SqlDataSource(con.ConnectionString, str);
                ds1.SelectParameters.Add("id", id);
                (item.FindControl("answers") as Repeater).DataSource = ds1;
                (item.FindControl("answers") as Repeater).DataBind();
            }
            
        }

        public static string TextForId(string id, string table) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "";
            switch (table)
            {
                case "tempquestions":
                    str = "select text from tempquestions where question_id = @id";
                    break;
                case "tempanswer":
                    str = "select text from tempanswer where answer_id = @id";
                    break;
                default:
                    return "";                    
            }

            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", id);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) {
                    dr.Read();
                    return dr["text"].ToString(); ;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
            return "";
        }

        public static void DelTempQuestion(string id) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "delete from tempanswer where question_id = @id";
            SqlCommand ans = new SqlCommand(str, con);
            ans.Parameters.AddWithValue("id", id);
            try
            {
                con.Open();
                ans.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }

            str = "delete from tempquestions where question_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                con.Close();
            }
        }

        public static void DelTempAnswer(string id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "delete from tempanswer where answer_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool CheckTempAnswer(string id) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select correct from tempanswer where answer_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", id);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return bool.Parse(dr["correct"].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                con.Close();
            }

            return false;
        }

        public static void UpdateTempQuestion(string id, string text, string points) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "update  tempQuestions set text=@text, points=@points where question_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("text", text);
            cmd.Parameters.AddWithValue("points", points);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public static string PointsToQuestion(string id){
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select points from tempquestions where question_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", id);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return dr["points"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }

            return "";
        }


        internal static void UpdateTempAnswer(string id, string text, bool check)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "update  tempanswer set text=@text, correct=@correct where answer_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("text", text);
            cmd.Parameters.AddWithValue("correct", check);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
      
        public static int CategoriesId(string name) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select cat_id from categories where categories_name = @name";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("name", name);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return int.Parse(dr["cat_id"].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                con.Close();
            }
            return 0;

        }

        public static string QuestionTempId(string text)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select question_id from tempquestions where text = @text";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("text", text);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return dr["question_id"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            return null;
        }


        public static string QuestionId(string text) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select question_id from question where text = @text";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("text", text);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return dr["question_id"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            return null;
        }

        public static void CopyTempTest(string id, string user_id) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            insertTest(SelectTempTest(id));
            string newTest_id = TestId(id);
            string str = "select * from tempquestions where test_id = @id";
            string questint_id = "";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", id);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                    while (dr.Read()) {
                        QuestionItem QI = new QuestionItem(dr["text"].ToString(), dr["points"].ToString());
                        insertQuestion(QI, user_id);
                        questint_id = QuestionId(dr["text"].ToString());
                        insertTestQuestion(questint_id, newTest_id);
                        copyAnswerForQuestion(dr["question_id"].ToString(), questint_id);
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

        private static void copyAnswerForQuestion(string oldQuestion_id, string newQuestion_id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string select = "select * from tempanswer where question_id = @id";
            SqlCommand cmdSelect = new SqlCommand(select, con);
            cmdSelect.Parameters.AddWithValue("id", oldQuestion_id);
            try
            {
                con.Open();
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if(dr.HasRows)
                    while (dr.Read())
                    {
                        insertAnswer(new AnswerItem(dr["text"].ToString(), dr["correct"].ToString()), newQuestion_id);
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

        private static void insertAnswer(AnswerItem ai, string Question_id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "insert into answer (answer_text, correct, question_id) values (@text, @correct, @id)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("text",ai.Text);
            cmd.Parameters.AddWithValue("correct", ai.Correct);
            cmd.Parameters.AddWithValue("id", Question_id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
        }

        private static void insertTestQuestion(string question_id, string test_id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "insert into test_question (question_id,  test_id) values (@question_id, @test_id)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("question_id",question_id);
            cmd.Parameters.AddWithValue("test_id",test_id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
        }

        private static string TestId(string id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select name from temptest where test_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", id);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    string name = dr["name"].ToString();
                    dr.Close();
                    str = "select test_id from test where name = @name";
                    cmd.CommandText = str;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("name", name);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        dr.Read();
                        return dr["test_id"].ToString();
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
            return null;
        }

        private static void insertQuestion(QuestionItem qi, string user_id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "insert into question (text, user_id, points) values (@text, @user_id, @points)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("text", qi.Text);
            cmd.Parameters.AddWithValue("user_id",user_id);
            cmd.Parameters.AddWithValue("points",qi.Points);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
        }

        private static testItem SelectTempTest(string id) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select * from temptest where test_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", id);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    string [] test= new string[dr.FieldCount];
                    testItem item = new testItem(dr["test_id"].ToString(), dr["name"].ToString(), dr["user_id"].ToString(), dr["cat_id"].ToString());
                    return item;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
            return null;
        }

        private static void insertTest(testItem test)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "insert into test (name, user_id, cat_id) values (@name, @user_id, @cat_id)";
            SqlCommand cmd = new SqlCommand(str, con);            
            try
            {
                con.Open();                
                cmd.Parameters.AddWithValue("name", test.Name);
                cmd.Parameters.AddWithValue("user_id", test.UserId);
                cmd.Parameters.AddWithValue("cat_id", test.CategoriesID);
                cmd.ExecuteNonQuery();                
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
        }

        internal static void DeleteTempTest(string test_id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            deleteTempQuestions(test_id);
            string delTest = "delete from temptest where test_id = @id";
            SqlCommand cmd = new SqlCommand(delTest, con);
            cmd.Parameters.AddWithValue("id", test_id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
        }

        private static void deleteTempQuestions(string test_id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select * from tempquestions where test_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", test_id);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DeleteTempAnswer(dr["question_id"].ToString());
                }
                dr.Close();
                string delQuest = "delete from tempQuestions where test_id = @id";
                cmd.CommandText = delQuest;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", test_id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
        }

        private static void DeleteTempAnswer(string id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "delete from tempanswer where question_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
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