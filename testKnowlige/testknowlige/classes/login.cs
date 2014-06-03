using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;

namespace TestKnowlige.classes
{
    public class LoGiN
    {
        public static bool CheckUser(string log, string password)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
            string str = "select firstname from users where login=@login and password=@password";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("login", log);            
            cmd.Parameters.AddWithValue("password", CreateLoGiN.EncodePassword(password));
            try
            {
                con.Open();
                if (!cmd.ExecuteReader().HasRows) return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool CheckLogin(string login)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
            string str = "select firstname from users where login=@login";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("login", login);
            try
            {
                con.Open();
                if (!cmd.ExecuteReader().HasRows) return false;
                return true;
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

        public static int UserId(string User) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select user_id from users where login = @log", con);
            cmd.Parameters.AddWithValue("log", User.Trim());
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return int.Parse(dr["user_id"].ToString());
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

        public static string SpetialQuestion(string login) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select question from users where login = @login";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("login", login);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) {
                    dr.Read();
                    return dr["question"].ToString();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }

        }

        internal static bool checkAnswer(string login, string question, string answer)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select firstname from users where login =@login and question = @question and answer = @answer";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("login", login);
            cmd.Parameters.AddWithValue("question", question);
            cmd.Parameters.AddWithValue("answer", answer);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
        }

        public static string RandomePassword()
        {         
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path.Remove(8);         
        }

        internal static void UpdatePassword(string login, string pass)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "update users set password = @password where login = @login";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("login", login);
            cmd.Parameters.AddWithValue("password",CreateLoGiN.EncodePassword(pass));
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

        public static bool UpdatePass(string pass, string login)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string str = "update users set password = @password where login=@login";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("password", CreateLoGiN.EncodePassword(pass));
            cmd.Parameters.AddWithValue("login", login);
            try
            {
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                return false;
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

        internal static string LoginForID(int user_id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select login from users where user_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", user_id.ToString());
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return dr["login"].ToString();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }


    }
}