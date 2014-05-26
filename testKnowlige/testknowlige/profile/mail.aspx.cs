using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using TestKnowlige.classes;

namespace TestKnowlige.profile
{
    public partial class mail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { 
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
                string str = "select im.readornot, mes.message_id, mes.text, us.login from users as u inner join inputMessage as im on "
                    + " u.user_id = im.user_id inner join message as mes on mes.message_id = im.message_id "
                    + " inner join outputMessage as om on om.message_id = im.message_id "
                    + " inner join users as us on us.user_id = om.user_id where u.user_id = @id";                
                SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
                ds.SelectParameters.Add("id", LoGiN.UserId(User.Identity.Name).ToString());
                listMessage.DataSource = ds;
                listMessage.DataBind();
            }
            menu.ActiveItem(4);
        }

        protected void NewMessage_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "SELECT im.ReadOrNot, mes.message_id, mes.text, u.login "
                         + " FROM Users AS u INNER JOIN "
                         + " InputMessage AS im ON u.user_id = im.user_id INNER JOIN "
                         + " Message AS mes ON mes.message_id = im.message_id INNER JOIN "
                         + " OutputMessage AS om ON om.message_id = mes.message_id INNER JOIN "
                         + " Users AS us ON us.user_id = om.user_id "
            + "where im.user_id = @id and im.show = @yes";            
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            ds.SelectParameters.Add("id", LoGiN.UserId(User.Identity.Name).ToString());
            ds.SelectParameters.Add("yes", true.ToString());
            listMessage.DataSource = ds;
            listMessage.DataBind();
        }

        protected void SenderMessage_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);            
            string str = "SELECT im.ReadOrNot, mes.message_id, mes.text, u.login FROM Users AS u INNER JOIN " 
                         + " InputMessage AS im ON u.user_id = im.user_id INNER JOIN " 
                         + " Message AS mes ON mes.message_id = im.message_id INNER JOIN "
                         + " OutputMessage AS om ON om.message_id = mes.message_id INNER JOIN "
                + " Users AS us ON us.user_id = om.user_id where om.user_id = @id and om.show = @yes";
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);
            ds.SelectParameters.Add("id", LoGiN.UserId(User.Identity.Name).ToString());
            ds.SelectParameters.Add("yes", true.ToString());
            listMessage.DataSource = ds;
            listMessage.DataBind();
        }

        protected void SendMessage_Click(object sender, ImageClickEventArgs e)
        {
            messageItem.FromUser = User.Identity.Name;
            messageItem.EnableToUser = true;
            messageItem.Visible = true;
        }

        protected void refreshMessage_Click(object sender, ImageClickEventArgs e)
        {
            listMessage.DataBind();
        }

        protected void deleteMessage_Click(object sender, ImageClickEventArgs e)
        {            
            foreach (RepeaterItem item in listMessage.Controls)
            {
                if ((item.FindControl("selectMessage") as CheckBox).Checked)
                    Mail.DeleteOutputMessage(int.Parse((item.FindControl("message_id") as HiddenField).Value));
            }

            listMessage.DataBind();
        }
    }
}