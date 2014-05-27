using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Web.Configuration;
using TestKnowlige.classes;

namespace TestKnowlige.usercontrol
{
    public partial class Message : System.Web.UI.UserControl
    {
        public string FromUser { get; set; }
        public string ToUsers { get; set; }
        public string Text { get; set; }
        public string HideField { get; set; }

        public bool EnableFrom { get; set; }
        public bool EnableToUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!string.IsNullOrEmpty(txtFrom.Text) && !string.IsNullOrEmpty(txtToUser.Text))
            {
                FromUser = txtFrom.Text;
                ToUsers = txtToUser.Text;
                Text = txtMessage.Text;
                EnableToUser = txtToUser.Enabled;
                EnableFrom = txtFrom.Enabled;
            }
        }

        protected void SendMessage_Click(object sender, EventArgs e)
        {
            if (Mail.SendMessage(txtMessage.Text, FromUser, ToUsers, errorMessage) <= 0)
            {
                errorMessage.Visible = true;                
            }
            else
            {
                this.Visible = false;
                FromUser = null;
                ToUsers = null;
                Text = null;                
                errorMessage.Visible = false;
                Page.FindControl("sendMessage").Visible = true;
                string js = "$('.send').animate({'opacity':'0.2'},500).animate({'opacity':'1'},500).animate({'opacity':'0.2'},500).animate({'opacity':'1'},500).animate({'opacity':'0.2'},500).animate({'opacity':'1'},500).fadeOut(2000)";
                Page.ClientScript.RegisterStartupScript(GetType(), "hideMessage", js, true);
            }
        }

        public int MyProperty { get; set; }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FromUser = null;
            ToUsers = null;
            Text = null;
            errorMessage.Visible = false;
            txtMessage.Text = "";            
        }
                
        protected void Page_PreRender(object sender, EventArgs e) {
            txtFrom.Text = FromUser;
            txtToUser.Text = ToUsers;
            txtMessage.Text = Text;            

            txtFrom.Enabled = EnableFrom;
            txtToUser.Enabled = EnableToUser;
        }
    }
}