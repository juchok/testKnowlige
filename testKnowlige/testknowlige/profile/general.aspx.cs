using System;
using System.Web.UI;
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
            if (!Page.IsPostBack)
            {
                try
                {
                    Profile.Information(User.Identity.Name, txtFirstname, "FirstName");
                    Profile.Information(User.Identity.Name, txtLastname, "lastname");
                    Profile.Information(User.Identity.Name, txtQuestion, "question");
                    Profile.Information(User.Identity.Name, txtAnswer, "answer");
                }
                catch (Exception ex) {
                    MessageError.Text = ex.Message;
                    MessageError.Visible = true;
                }
            }
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
            try
            {
                Profile.Save(User.Identity.Name, txtFirstname.Text, txtLastname.Text, txtQuestion.Text, txtAnswer.Text);
            }
            catch (Exception ex)
            {
                MessageError.Text = ex.Message;
                MessageError.Visible = true;
            }
            txtAnswer.Enabled = false;
            txtQuestion.Enabled = false;
            txtFirstname.Enabled = false;
            txtLastname.Enabled = false;
            Change.Visible = true;
            Save.Visible = false;
            Cancel.Visible = false;

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/profile/general.aspx");
        }
    }
}