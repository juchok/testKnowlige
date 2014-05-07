﻿using System;
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
            if (!LoGiN.CheckLogin(txtLogin.Text)
                && CreateLoGiN.createAccaunt(txtFirstname.Text, txtLastname.Text, txtLogin.Text, txtPassword.Text, txtQuestion.Text, txtAnswer.Text, DDList.SelectedValue)) {
                    FormsAuthentication.RedirectFromLoginPage(txtLogin.Text, true);
            }
        }
    }
}