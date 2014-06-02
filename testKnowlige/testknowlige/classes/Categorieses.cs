using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TestKnowlige.classes
{
    public class Categorieses
    {
        internal static void NewCategories(string Categories_name, string Discipline_id, string Author)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "insert into categories (discipline_id, categories_name, user_id) values (@dis_id, @name, @id)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("dis_id", Discipline_id);
            cmd.Parameters.AddWithValue("name", Categories_name);
            cmd.Parameters.AddWithValue("id", LoGiN.UserId(Author));
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ApplicationException("Не удалось добавить Дисцплину");
            }
            finally {
                con.Close();
            }
        }
    }
}