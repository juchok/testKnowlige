using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TestKnowlige.classes
{
    public class Users
    {
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
                if (dr.HasRows) {
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