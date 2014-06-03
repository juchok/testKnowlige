using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace TestKnowlige.classes
{
    public class Mail
    {
        public static int SendMessage(string text, string FromUser, string ToUser, Label errorMessage){

            int id_FromUer = LoGiN.UserId(FromUser);
            if (id_FromUer <= 0) {
                errorMessage.Text = "Не существует такого отправителя";                
                return 0;
            }

            int id_ToUser = LoGiN.UserId(ToUser);
            if (id_ToUser <= 0) {
                errorMessage.Text = "Не существует такого получателя";
                return 0;
            }
            
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "insert into Message (text, date) values (@text, @date) SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("text", text);
            cmd.Parameters.AddWithValue("date", DateTime.Now);
            try
            {
                con.Open();                
                int id_message = int.Parse(cmd.ExecuteScalar().ToString());
                if (id_message <= 0) {
                    errorMessage.Text = "Не удалось отправить сообщение";
                    return 0;
                                    }
                cmd.CommandText = "insert into inputMessage (user_id, readornot, message_id, show) values (@user_id, @read, @message_id, @tru)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("user_id", id_ToUser);
                cmd.Parameters.AddWithValue("read", 0);
                cmd.Parameters.AddWithValue("message_id", id_message);
                cmd.Parameters.AddWithValue("tru", true);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into outputMessage (user_id, message_id, show) values (@user_id, @message_id, @tru)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("user_id", id_FromUer);
                cmd.Parameters.AddWithValue("message_id", id_message);
                cmd.Parameters.AddWithValue("tru", true);
                cmd.ExecuteNonQuery();

                return 1;
            }
            catch
            {
                errorMessage.Text = "Не удалось отправить сообщение";
                return 0;
            }
            finally
            {
                con.Close();
            }            
        }

        public static void DeleteOutputMessage(int messageID) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "update outputmessage set show = @fals where message_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("fals", false);
            cmd.Parameters.AddWithValue("id", messageID.ToString());
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ApplicationException("Не удалось удалить отправленные сообщения");
            }
            finally {
                con.Close();
            }

        }

        internal static void GiveMessage(Repeater listMessage, int id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "SELECT im.ReadOrNot, mes.message_id, mes.text, us.login "
                         + " FROM Users AS u INNER JOIN "
                         + " InputMessage AS im ON u.user_id = im.user_id INNER JOIN "
                         + " Message AS mes ON mes.message_id = im.message_id INNER JOIN "
                         + " OutputMessage AS om ON om.message_id = mes.message_id INNER JOIN "
                         + " Users AS us ON us.user_id = om.user_id "
            + "where im.user_id = @id and im.show = @yes";
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            ds.SelectParameters.Add("id", id.ToString());
            ds.SelectParameters.Add("yes", true.ToString());
            listMessage.DataSource = ds;
            listMessage.DataBind();
        }

        internal static void SentMessage(Repeater listMessage, int id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "SELECT im.ReadOrNot, mes.message_id, mes.text, u.login FROM Users AS u INNER JOIN "
                         + " InputMessage AS im ON u.user_id = im.user_id INNER JOIN "
                         + " Message AS mes ON mes.message_id = im.message_id INNER JOIN "
                         + " OutputMessage AS om ON om.message_id = mes.message_id INNER JOIN "
                + " Users AS us ON us.user_id = om.user_id where om.user_id = @id and om.show = @yes";
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            ds.SelectParameters.Add("id", id.ToString());
            ds.SelectParameters.Add("yes", true.ToString());
            listMessage.DataSource = ds;
            listMessage.DataBind();
        }

        internal static void DeleteInputMessage(int messageID)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "update inputmessage set show = @fals where message_id = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("fals", false);
            cmd.Parameters.AddWithValue("id", messageID.ToString());
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ApplicationException("Не удалось удалить входящие сообщения");
            }
            finally
            {
                con.Close();
            }
        }
    }
}