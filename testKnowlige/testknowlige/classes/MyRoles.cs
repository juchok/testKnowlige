using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace TestKnowlige.classes
{
    public class MyRoles
    {
        public static bool IsUserInRole(string user, string role) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "";
            str = "select COUNT(*) from users as u inner join " + role +" as r on r.user_id = u.user_id where u.login = @user";           
            SqlCommand cmd = new SqlCommand(str, con);            
            cmd.Parameters.AddWithValue("@user", user);
            try
            {
                con.Open();
                if ((int)cmd.ExecuteScalar() > 0)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally {
                con.Close();
            }
            return false;
        }

        public static void AddUserToRole(string user, string role) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            bool rol = true;
            string str = "insert into " + role +" (user_id) values (@id)";
            
            if (rol)
            {
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("@id", LoGiN.UserId(user));
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }                
                finally
                {
                    con.Close();
                }                
            }
        }
    }
}