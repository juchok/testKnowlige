using System;
using System.Web.UI;
using TestKnowlige.classes;

namespace TestKnowlige.profile
{
    public partial class more : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                Response.Redirect("~/default.aspx");
            }
            if (!Page.IsPostBack)
            {
                Profile.MoreInformation(User.Identity.Name, txtMail, "Mail");
                Profile.MoreInformation(User.Identity.Name, txtPhone, "Phone");
                Profile.MoreInformation(User.Identity.Name, txtAddress, "address");
            }
            menu.ActiveItem(2);
        }

        protected void Change_Click(object sender, EventArgs e)
        {
            txtAddress.Enabled = true;
            txtMail.Enabled = true;
            txtPhone.Enabled = true;
            Change.Visible = false;
            Save.Visible = true;
            Cancel.Visible = true;
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            Profile.SaveMoreInformation(User.Identity.Name, txtMail.Text, txtPhone.Text, txtAddress.Text);
            txtAddress.Enabled = false;
            txtMail.Enabled = false;
            txtPhone.Enabled = false;
            Change.Visible = true;
            Save.Visible = false;
            Cancel.Visible = false;
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/profile/more.aspx");
        }
    }
}