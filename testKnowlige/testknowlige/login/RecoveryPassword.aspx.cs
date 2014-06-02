using System;
using System.Web.UI;
using TestKnowlige.classes;
using System.Web.Security;

namespace TestKnowlige.login
{
    public partial class RecoveryPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string js = "setTimeout(\"$('#lblPass').animate({'opacity':'0.2'},300).animate({'opacity':'1'},300).animate({'opacity':'0.2'},300).animate({'opacity':'1'},300).animate({'opacity':'0.2'},300).animate({'opacity':'1'},300)\", 500)";
            Page.ClientScript.RegisterStartupScript(GetType(), "hideMessage", js, true);
                        
            if (!Page.IsPostBack)
            {
                RecoveryPass.SetActiveView(yourLogin);
            }
        }

        protected void btnNext_view1_Click(object sender, EventArgs e)
        {
            if (LoGiN.CheckLogin(txtLogin.Text))
            {
                lblQuestion.Text = LoGiN.SpetialQuestion(txtLogin.Text);
                hidelogin.Value = txtLogin.Text;
                RecoveryPass.SetActiveView(yourAnswer);
            }
            else {
                loginError.Visible = true;
            }
        }

        protected void btnCancel_view1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnNext_view2_Click(object sender, EventArgs e)
        {
            if (LoGiN.checkAnswer(hidelogin.Value, lblQuestion.Text, txtAnswer.Text))
            {
                string pass = LoGiN.RandomePassword();
                lblPass.Text = pass;
                LoGiN.UpdatePassword(hidelogin.Value, pass);
                hideLog.Value = hidelogin.Value;
                RecoveryPass.SetActiveView(newPass);
                
            }
            else {
                answerError.Visible = true;
            }
        }        

        protected void btnCancel_view2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            FormsAuthentication.RedirectFromLoginPage(hideLog.Value, true);
        }
    }
}