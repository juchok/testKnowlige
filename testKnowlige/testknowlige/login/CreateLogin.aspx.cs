using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using TestKnowlige.classes;

namespace TestKnowlige.login
{
    public partial class CreateLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (!LoGiN.CheckLogin(txtLogin.Text))
            {
                if (DDList.SelectedValue.ToLower() != "admin")
                {
                    if (CreateLoGiN.createAccaunt(txtFirstname.Text, txtLastname.Text, txtLogin.Text, txtPassword.Text, txtQuestion.Text, txtAnswer.Text, DDList.SelectedValue))
                    {
                        FormsAuthentication.RedirectFromLoginPage(txtLogin.Text, true);
                    }
                    else
                    {
                        ErrorMessage.Text = "Не удалось создать пользователя";
                        ErrorMessage.Visible = true;
                    }
                }
                else {
                    if (CreateLoGiN.WaitAcaunt(txtFirstname.Text, txtLastname.Text, txtLogin.Text, txtPassword.Text, txtQuestion.Text, txtAnswer.Text, DDList.SelectedValue, txtPhone.Text, txtMail.Text))
                    {
                        ErrorMessage.Text = "Акаунт успешно добавлен, в скором времени с вами свяжутся";
                        ErrorMessage.Visible = true;
                         
                    }
                    else
                    {
                        ErrorMessage.Text = "Не удалось создать пользователя";
                        ErrorMessage.Visible = true;
                    }
                }
            }
            else {
                LoginBusy.Text = "Логин занят";
                LoginBusy.Visible = true;
                txtLogin.Text = "";
                txtLogin.Focus();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void ChangedCategories(object sender, EventArgs e) {
            if ((sender as DropDownList).SelectedIndex == 3)
            {
                mail.Visible = true;
                phone.Visible = true;
            }
            else {
                mail.Visible = false;
                phone.Visible = false;
            }
        }
    }
}