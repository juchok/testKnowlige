using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace TestKnowlige.classes
{
    public class Discipliness
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

        internal static string DisciplineForTest(string test_id) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select d.discipline_name from test as t " +
                    " inner join categories as c on c.cat_id = t.cat_id " +
                    " inner join discipline as d on d.discipline_id = c.discipline_id " +
                    " where t.test_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", test_id);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return dr["discipline_name"].ToString();
                }
                throw new ApplicationException("Не найден тест с таким Id");
            }
            catch (Exception)
            {
                throw new ApplicationException("Произошла ошибка при поиске теста");
            }
            finally {
                con.Close();
            }

        }

        public static SqlDataSource DisciplineList()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select discipline_name from discipline";
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            return ds;
        }

        internal static SqlDataSource DisciplineListHasCategories()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select distinct d.discipline_name from discipline as d "
                + " inner join Categories as c on c.discipline_id = d.discipline_id "
                + " where c.categories_name is not null";
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            return ds;
        }

        internal static void UpdateDisciplineName(int indexRow, string new_name)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            int id = DisciplineId(indexRow);
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
                    throw new ApplicationException("Не удалось обновить дисциплину");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        internal static int DisciplineId(int indexRow)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select discipline_id from discipline";
            SqlCommand cmd = new SqlCommand(str, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (i == indexRow)
                    {
                        return int.Parse(dr["discipline_id"].ToString());
                    }
                    i++;
                }
                return 0;
            }
            catch (Exception)
            {
                throw new ApplicationException("Не удалось найти индекс дисциплины");
            }
            finally
            {
                con.Close();
            }
        }

        public static string DisciplineId(string disc)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select discipline_id from discipline where discipline_name = @name";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("name", disc);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return dr["discipline_id"].ToString();
                }
                return null;
            }
            catch (Exception)
            {
                throw new ApplicationException("Не удалось найти индекс дисциплины");
            }
            finally
            {
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
            finally
            {
                con.Close();
            }

        }

        public static string DefaultDiscipline()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select top(1) discipline_name from discipline";
            SqlCommand cmd = new SqlCommand(str, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return dr["discipline_name"].ToString();
                }
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                con.Close();
            }
            return "";
        }

        public static bool Discipline(Repeater userControl, string command)
        {
            SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, command);
            if (!Count(command))
            {
                return false;
            }
            try
            {
                userControl.DataSource = ds;
                userControl.DataBind();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Count(string command)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            SqlCommand cmd = new SqlCommand(command, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) return true;
                return false;
            }
            finally
            {
                con.Close();
            }
        }        

        internal static void DisciplineList(DropDownList discipline)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select discipline_name from discipline";
            SqlCommand cmd = new SqlCommand(str, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    discipline.Items.Add(new ListItem(dr["discipline_name"].ToString()));
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
        }

        internal static void activeDiscipline(DropDownList discipline, string test_id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select d.discipline_name from discipline as d "
            + " inner join categories as c on c.discipline_id = d.discipline_id "
            + " inner join test as t on c.cat_id = t.cat_id where t.test_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", test_id);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    int i = 0;
                    foreach (ListItem item in discipline.Items)
                    {
                        if (item.Text == dr["discipline_name"].ToString())
                        {
                            discipline.Items[i].Selected = true;
                            break;
                        }
                        i++;
                    }
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
        }
    }
}