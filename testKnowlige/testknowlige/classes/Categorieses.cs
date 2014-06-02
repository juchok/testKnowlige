using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

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

        internal static string CategoriesForTest(string test_id) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select c.categories_name from test as t " +
                    " inner join categories as c on c.cat_id = t.cat_id " +                    
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
                    return dr["categories_name"].ToString();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
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

        internal static object CategoriesList(string dis_name)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select c.categories_name from discipline as d "
                + " inner join categories as c on c.discipline_id = d.discipline_id "
                + " where discipline_name = @name";
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            ds.SelectParameters.Add("name", dis_name);
            return ds;
        }

        internal static void UpdateCategories(string disc, string cat_name, int cat_id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "update categories set categories_name = @name, discipline_id = @dis_id where cat_id = @cat_id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("name", cat_name);
            cmd.Parameters.AddWithValue("dis_id", Discipliness.DisciplineId(disc));
            cmd.Parameters.AddWithValue("cat_id", cat_id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ApplicationException("Не удалось обновить категорию");
            }
            finally
            {
                con.Close();
            }
        }

        internal static int CategoriesID(int indexRow)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select c.cat_id from discipline as d "
                + " inner join categories as c on c.discipline_id = d.discipline_id";
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
                        return int.Parse(dr["cat_id"].ToString());
                    }
                    i++;
                }
                return 0;
            }
            catch (Exception)
            {
                throw new ApplicationException("Индекс категории не найден");
            }
            finally
            {
                con.Close();
            }
        }

        internal static bool deleteCategories(string cat_name)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "delete categories where categories_name = @name";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("name", cat_name);
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

        public static bool? Categories(Repeater userControl, string getstr)
        {
            if (string.IsNullOrEmpty(getstr))
            {
                return null;
            }
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select discipline_id from discipline where Discipline_name = @name", con);
            cmd.Parameters.AddWithValue("name", getstr);

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    string str = "";
                    while (dr.Read())
                    {
                        str = dr["discipline_id"].ToString();
                        if (!string.IsNullOrEmpty(str))
                            break;
                    }

                    dr.Close();
                    SqlCommand cm = new SqlCommand("select categories_name from categories where discipline_id = @id", con);
                    cm.Parameters.AddWithValue("id", str);
                    dr = cm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, cm.CommandText);
                        ds.SelectParameters.Add("id", str);
                        userControl.DataSource = ds;
                        userControl.DataBind();
                        return true;
                    }

                }
                return false;
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

        internal static void CategoriesList(DropDownList categories)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select categories_name from categories";
            SqlCommand cmd = new SqlCommand(str, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    categories.Items.Add(new ListItem(dr["categories_name"].ToString()));
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

        internal static void activeCategories(DropDownList categories, string test_id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select c.categories_name from categories as c "
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
                    foreach (ListItem item in categories.Items)
                    {
                        if (item.Text == dr["categories_name"].ToString())
                        {
                            categories.Items[i].Selected = true;
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

        internal static void ChangeCategories(string test_id, int categories_id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "update test set cat_id = @cat_id where test_id = @test_id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("test_id", test_id);
            cmd.Parameters.AddWithValue("cat_id", categories_id);
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

        public static int CategoriesId(string name)
        {
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
            finally
            {
                con.Close();
            }
            return 0;

        }
    }
}