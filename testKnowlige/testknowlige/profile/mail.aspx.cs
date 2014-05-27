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
            if(!Page.IsPostBack)
            {
                NewMessage_Click(sender, e);
            }
            
            menu.ActiveItem(4);
        }

        protected void SendMessage_Click(object sender, ImageClickEventArgs e)
        {
            messageItem.FromUser = User.Identity.Name;
            messageItem.EnableToUser = true;
            messageItem.Visible = true;
        }

        protected void refreshMessage_Click(object sender, ImageClickEventArgs e)
        {
            if (WhatList.Value.ToLower() == "sent")
            {
                SenderMessage_Click(sender, e);
            }
            else {
                NewMessage_Click(sender, e);
            }
        }

        protected void deleteMessage_Click(object sender, ImageClickEventArgs e)
        {            
            foreach (RepeaterItem item in listMessage.Controls)
            {
                if ((item.FindControl("selectMessage") as CheckBox).Checked)
                {
                    if (WhatList.Value.ToLower() == "new") {
                        Mail.DeleteInputMessage(int.Parse((item.FindControl("message_id") as HiddenField).Value));
                    }
                    else if (WhatList.Value.ToLower() == "sent") {
                        Mail.DeleteOutputMessage(int.Parse((item.FindControl("message_id") as HiddenField).Value));
                    }
                }                    
            }

            refreshMessage_Click(sender, e);
        }

        protected void SenderMessage_Click(object sender, EventArgs e)
        {            
            Mail.SentMessage(listMessage, LoGiN.UserId(User.Identity.Name));
            WhatList.Value = "sent";
            SenderMessage.CssClass = "active_mail";
            NewMessage.CssClass = "";
        }

        protected void NewMessage_Click(object sender, EventArgs e)
        {         
            Mail.GiveMessage(listMessage, LoGiN.UserId(User.Identity.Name));
            WhatList.Value = "new";
            NewMessage.CssClass = "active_mail";
            SenderMessage.CssClass = "";
        }
    }
}