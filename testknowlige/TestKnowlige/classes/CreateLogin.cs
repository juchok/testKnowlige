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
                        string str = "insert into users (firstname, lastname, login, password, question, answer, categories) values('" +
                        firstname + "', '" + lastname + "', '" + login + "', '" + password.GetHashCode().ToString() + "', '" + question + "', '" + answer + "', '"+categor+"')";
                        SqlCommand cmd = new SqlCommand(str, con);
                        SqlCommand cmdlogin = new SqlCommand("select count(*) from user where login='"+login+"'", con);                        
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