using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

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
            cmd.Parameters.AddWithValue("password", password.GetHashCode().ToString());
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
            cmd.Parameters.AddWithValue("log", User);
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
    }
}