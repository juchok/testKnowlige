using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestKnowlige.classes;

namespace TestKnowlige.profile
{
    public partial class general : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                Response.Redirect("~/default.aspx");
            }
            Profile.Information(User.Identity.Name, txtFirstname, "FirstName");
            Profile.Information(User.Identity.Name, txtLastname, "lastname");
            Profile.Information(User.Identity.Name, txtQuestion, "question");
            Profile.Information(User.Identity.Name, txtAnswer, "answer");
            menu.ActiveItem(1);
        }

        protected void Change_Click(object sender, EventArgs e)
        {
            txtAnswer.Enabled = true;
            txtQuestion.Enabled = true;
            txtFirstname.Enabled = true;
            txtLastname.Enabled = true;
            Change.Visible = false;
            Save.Visible = true;
            Cancel.Visible = true;
        }

        protected void Save_Click(object sender, EventArgs e)
        {            
            Profile.Save(User.Identity.Name, txtFirstname.Text, txtLastname.Text, txtQuestion.Text, txtAnswer.Text);            
            Response.Redirect("~/profile/general.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/profile/general.aspx");
        }
    }
}