using System;
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
                string login = LoGiN.LoginForID(info.UserId);
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

        internal static SqlDataSource AdminsList() {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select firstname, lastname, login from users where categories='admin'";
            /* ----- Сделать проверку если нет списка --------*/
            return new SqlDataSource(con.ConnectionString, str);

        }
    }
};