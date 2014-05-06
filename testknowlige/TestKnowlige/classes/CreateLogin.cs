using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

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
                        cmd.Parameters.AddWithValue("password", password.GetHashCode().ToString());
                        cmd.Parameters.AddWithValue("question", question);
                        cmd.Parameters.AddWithValue("answer", answer);
                        cmd.Parameters.AddWithValue("categories", categor);
                        SqlCommand cmdlogin = new SqlCommand("select count(*) from user where login=@login", con);
                        cmdlogin.Parameters.AddWithValue("login", login);
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
            return false;
        }
    }
}