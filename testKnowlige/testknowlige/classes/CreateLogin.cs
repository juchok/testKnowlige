using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace TestKnowlige.classes
{
    public class CreateLoGiN
    {
        static public bool createAccaunt(string firstname, string lastname, string login, string password, string question, string answer, string categor) {                               
            if(!LoGiN.CheckLogin(login))
                if (!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lastname) && !string.IsNullOrEmpty(login)
                    && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(question) && !string.IsNullOrEmpty(answer)
                    ) {
                        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);                        
                        string str = "insert into users (firstname, lastname, login, password, question, answer, categories) values(@firstname, @lastname, @login, @password, @question, @answer, @categories)";                       
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.Parameters.AddWithValue("firstname", firstname);
                        cmd.Parameters.AddWithValue("lastname", lastname);
                        cmd.Parameters.AddWithValue("login", login);
                        cmd.Parameters.AddWithValue("password", EncodePassword(password));
                        cmd.Parameters.AddWithValue("question", question);
                        cmd.Parameters.AddWithValue("answer", answer);
                        cmd.Parameters.AddWithValue("categories", categor);
                        SqlCommand cmdlogin = new SqlCommand("select count(*) from user where login=@login", con);
                        cmdlogin.Parameters.AddWithValue("login", login);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            if (categor == "Teacher")
                            {
                                Roles.AddUserToRole(login, "Teacher");
                            }
                            else if (categor == "Admin") {
                                Roles.AddUserToRole(login, "Admin");
                                }
                            else
                            {
                                Roles.AddUserToRole(login, "Student");                                
                            }
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
            return false;
        }

        public static string EncodePassword(string pass)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);            
            byte[] dst = new byte[bytes.Length];            
            Buffer.BlockCopy(bytes, 0, dst, 0, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        internal static bool WaitAcaunt(string firstname, string lastname, string login, string password, string question, string answer, string categor, string phone, string mail)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "insert into WaitUsers (firstname, lastname, mail, phone, login, password, answer, question, categories) "
                + " values(@firstname, @lastname, @phone, @mail, @login, @password, @answer, @question, @categories)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("firstname", firstname);
            cmd.Parameters.AddWithValue("Lastname", lastname);
            cmd.Parameters.AddWithValue("phone", phone);
            cmd.Parameters.AddWithValue("mail", mail);
            cmd.Parameters.AddWithValue("login", login);
            cmd.Parameters.AddWithValue("password", EncodePassword(password));
            cmd.Parameters.AddWithValue("answer", answer);
            cmd.Parameters.AddWithValue("question", question);
            cmd.Parameters.AddWithValue("categories", categor);
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

        internal static void AddMoreInformation(int user_id, string mail, string phone, string adress)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "insert into moreinformation (user_id, mail, phone,  address) values (@id, @mail, @phone, @address)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", user_id.ToString());
            cmd.Parameters.AddWithValue("mail", mail);
            cmd.Parameters.AddWithValue("phone", phone);
            cmd.Parameters.AddWithValue("address", adress);
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
    }
}