using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;


namespace TestKnowlige.classes
{
    public class Profile
    {
        public static void General(string userName) { 
        }

        internal static void Information(string UserName, TextBox txtFirstname, string Field)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select * from users where login = @login";
            SqlCommand cmd = new SqlCommand(str, con);
            //cmd.Parameters.AddWithValue("field", Field);
            cmd.Parameters.AddWithValue("login", UserName);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) {
                    dr.Read();
                    txtFirstname.Text = dr[Field].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
        }


        
        internal static void Save(string username, string firstname, string lastname, string question, string answer)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "update users set firstname=@firstname, lastname=@lastname, question=@question, answer=@answer where login = @login";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("firstname", firstname);
            cmd.Parameters.AddWithValue("lastname", lastname);
            cmd.Parameters.AddWithValue("question", question);
            cmd.Parameters.AddWithValue("answer", answer);
            cmd.Parameters.AddWithValue("login", username);
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

        internal static void SaveMoreInformation(string username, string mail, string phone, string address)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select m.phone, m.address, m.mail from moreinformation as m inner join" + 
            " user as u on u.user_id = m.user_id where u.login = @login";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("login", username);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();                
                if (dr.HasRows)
                {
                    str = "update moreinformation set phone=@phone, mail=@mail, address=@address where user_id=@id";
                }
                else {
                    str = " insert into moreinformation (phone, mail, address, user_id) values (@phone, @mail, @address, @id)";
                }
                cmd.CommandText = str;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("mail", mail);
                cmd.Parameters.AddWithValue("phone", phone);
                cmd.Parameters.AddWithValue("address", address);
                cmd.Parameters.AddWithValue("id", LoGiN.UserId(username));
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

        internal static void MoreInformation(string UserName, TextBox txtField, string field)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select * from moreinformation where user_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            //cmd.Parameters.AddWithValue("field", Field);
            cmd.Parameters.AddWithValue("id", LoGiN.UserId(UserName));
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    txtField.Text = dr[field].ToString();
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
