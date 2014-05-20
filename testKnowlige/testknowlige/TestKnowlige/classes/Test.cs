using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;


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
    }
}