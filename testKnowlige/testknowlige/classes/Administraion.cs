using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace TestKnowlige.classes
{
    public class Administraion
    {
        internal static bool AddAdmin(string login)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select * from waitusers where login = @login";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("login", login);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) {
                    dr.Read();
                    CreateLoGiN.createAccaunt(dr["firstname"].ToString(), dr["lastname"].ToString(), dr["login"].ToString(), dr["password"].ToString(), dr["question"].ToString(), dr["answer"].ToString(), dr["categories"].ToString());
                    CreateLoGiN.AddMoreInformation( LoGiN.UserId(login), dr["mail"].ToString(), dr["phone"].ToString(), "");
                    Administraion.DeleteWaitUser(login);
                    return true;
                }
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

        internal static void DeleteWaitUser(string login)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "delete from waitusers where login = @login";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("login", login);
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

        internal static SqlDataSource waitUserList()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select * from waitusers";
            string count = "select COUNT(*) from waitusers";
            SqlCommand cmd = new SqlCommand(count, con);
            try
            {
                con.Open();
                if (int.Parse(cmd.ExecuteScalar().ToString()) < 1)
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            return ds;
        }

        internal static SqlDataSource DisciplineList()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select discipline_name from discipline";
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            return ds;
        }

        internal static void UpdateDisciplineName(int indexRow, string new_name)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            int id = Administraion.DisciplineId(indexRow);
            if (id != 0)
            {
                string str = "update discipline set discipline_name = @new_name where discipline_id = @id";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("id", id.ToString());
                cmd.Parameters.AddWithValue("new_name", new_name);
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
        }

        private static int DisciplineId(int indexRow)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select discipline_id from discipline";
            SqlCommand cmd = new SqlCommand(str, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while(dr.Read()){                    
                    if (i == indexRow) {
                        return int.Parse(dr["discipline_id"].ToString());
                    }
                    i++;
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
        }

        internal static bool deleteDiscipline(string Discipline_name)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "delete discipline where discipline_name = @name";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("name", Discipline_name);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
            finally {
                con.Close();
            }
            
        }
        
        internal static SqlDataSource CategoriesList()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select d.discipline_name, c.categories_name from discipline as d "
                + " inner join categories as c on c.discipline_id = d.discipline_id";
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            return ds;
        }
    }
}