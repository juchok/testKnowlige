using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TestKnowlige.classes
{
    public class Disciplines
    {
        internal static void NewDiscipline(string Discipline_name, string Author)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "insert into discipline (discipline_name, user_id) values (@name, @id)";
            SqlCommand cmd = new SqlCommand(str, con);            
            cmd.Parameters.AddWithValue("name", Discipline_name);
            cmd.Parameters.AddWithValue("id", LoGiN.UserId(Author));
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ApplicationException("Не удалось добавить дисциплину");
            }
            finally
            {
                con.Close();
            }
        }
    }
}