﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Web.Security;

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
                throw new ApplicationException("Не удалось добавить нового пользователя в админы");
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
                throw new ApplicationException("Не удалось удалить пользователя из списка ожидающих ответа");
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
                throw new ApplicationException("Не удалось получить список пользователей ожидающих ответа");
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
                throw new ApplicationException("Не удалось найти индекс дисциплины");
            }
            finally {
                con.Close();
            }
        }

        internal static string DisciplineId(string disc)
        {            
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select discipline_id from discipline where discipline_name = @name";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("name", disc);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) {
                    dr.Read();
                    return dr["discipline_id"].ToString();
                }
                return null;
            }
            catch (Exception)
            {
                throw new ApplicationException("Не удалось найти индекс дисциплины");
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
            cmd.Parameters.AddWithValue("dis_id", DisciplineId(disc));
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
            finally {
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

        internal static SqlDataSource TestList()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select d.discipline_name, c.categories_name, t.name, t.test_id from test as t "
                + " inner join categories as c on c.cat_id = t.cat_id "
                + " inner join discipline as d on c.discipline_id = d.discipline_id";
            return new SqlDataSource(con.ConnectionString, str);
        }
        
        internal static void UpdateTest(string test_id, string test_name, string Select_Categories)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "update test set name = @test_name, cat_id = @cat_id where test_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("test_name", test_name);
            cmd.Parameters.AddWithValue("cat_id",Test.CategoriesId(Select_Categories));
            cmd.Parameters.AddWithValue("id", test_id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ApplicationException("Не удалось сохранить тест");
            }
            finally {
                con.Close();
            }
            
        }

        internal static SqlDataSource UserList()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select user_id, firstname, lastname, login, question, answer, categories from users";
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            return ds;
        }
                       
        internal static void UpdateUser(UserInfo info)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "update users set firstname = @firstname, lastname = @lastname, login = @login, question = @question, answer = @answer, categories = @categories where user_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("firstname", info.FirstName);
            cmd.Parameters.AddWithValue("lastname", info.LastName);
            cmd.Parameters.AddWithValue("login", info.Login);
            cmd.Parameters.AddWithValue("question", info.Question);
            cmd.Parameters.AddWithValue("answer", info.Answer);
            cmd.Parameters.AddWithValue("categories", info.Categories);            
            cmd.Parameters.AddWithValue("id", info.UserId);

            try
            {
                string login = Users.LoginForID(info.UserId);
                string usRole="";
                if(Roles.GetRolesForUser(login)[0].Length > 0)
                    usRole = Roles.GetRolesForUser(login)[0];                               

                con.Open();
                cmd.ExecuteNonQuery();  
                
                if (usRole != info.Categories) {
                    if(!string.IsNullOrEmpty(usRole))
                        Roles.RemoveUserFromRole(login, usRole);
                    Roles.AddUserToRole(login, info.Categories);
                }

            }
            catch (Exception)
            {
                throw new ApplicationException("Не удалось обновить информация о пользователе");
            }
            finally {
                con.Close();
            }
        }

        internal static void deleteUser(string login)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "delete users where login = @login";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("login", login);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ApplicationException("Не удалось удалить пользователя");
            }
            finally {
                con.Close();
            }
        }
    }
};