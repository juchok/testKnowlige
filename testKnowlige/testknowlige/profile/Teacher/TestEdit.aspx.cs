using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using TestKnowlige.classes;

namespace TestKnowlige.profile.Teacher
{
    public partial class TestEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(!Roles.IsUserInRole(User.Identity.Name, "Teacher") || !Roles.IsUserInRole(User.Identity.Name, "Admin")) || string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Response.Redirect("~/default.aspx");
            }
            
            testAuthor.Text = "Автор: " + User.Identity.Name;                            
            test_id.Value = Request.QueryString["id"];
            testName.Text = Test.TestName(test_id.Value);
            
            Test.TestBind(Page);            
        }

        protected void AddAnswer_Click(object sender, ImageClickEventArgs e)
        {
            EditTest.HideField = (sender as ImageButton).AlternateText;
            EditTest.HeaderToControl = "Добавить ответ";
            EditTest.TextControl = "Введите текст ответа";
            EditTest.VisibleBtnAnswer = true;
            EditTest.AnswerPanel = true;
            EditTest.Visible = true;
        }

        protected void AddQuestion_Click(object sender, ImageClickEventArgs e)
        {
            EditTest.HeaderToControl = "Новый вопрос";
            EditTest.TextControl = "Введите текст вопроса";
            EditTest.VisibleBtnQuestion = true;
            EditTest.QuestionPanel = true;
            EditTest.Visible = true;
        }

        private void defaultButton()
        {
            EditTest.HeaderToControl = "Новый тест";
            EditTest.TextControl = "Введите название теста";
            EditTest.VisibleBtnTest = true;
            EditTest.Visible = true;
        }

        protected void delQuestion_Click(object sender, ImageClickEventArgs e)
        {
            FormConfirm.Text = "Вопрос: " + Test.TextForId((sender as ImageButton).AlternateText, "question");
            FormConfirm.DelMessage = "Вы действительно хотите удалить вопрос?";
            FormConfirm.btnDelQuestion = true;
            FormConfirm.Id = (sender as ImageButton).AlternateText;
            FormConfirm.Visible = true;
        }

        protected void delAnswer_Click(object sender, ImageClickEventArgs e)
        {
            FormConfirm.Text = "Ответ: " + Test.TextForId((sender as ImageButton).AlternateText, "answer");
            FormConfirm.DelMessage = "Вы действительно хотите удалить ответ?";
            FormConfirm.btnDelAnswer = true;
            FormConfirm.Id = (sender as ImageButton).AlternateText;
            FormConfirm.Visible = true;
        }

        protected void RedactQuestion_Click(object sender, ImageClickEventArgs e)
        {
            EditTest.HeaderToControl = "Редактирование";
            EditTest.TextControl = "Введите текст вопроса";
            EditTest.Text = Test.TextForId((sender as ImageButton).AlternateText, "question");
            EditTest.Points = Test.PointsToQuestion((sender as ImageButton).AlternateText, "question");
            EditTest.HideField = (sender as ImageButton).AlternateText;
            EditTest.QuestionPanel = true;
            EditTest.VisibleBtnQuestion = false;
            EditTest.btnRedactQuestion = true;
            EditTest.Visible = true;
        }

        protected void RedactAnswer_Click(object sender, ImageClickEventArgs e)
        {
            EditTest.HideField = (sender as ImageButton).AlternateText;
            EditTest.HeaderToControl = "Редактирование";
            EditTest.TextControl = "Введите текст ответа";
            EditTest.Text = Test.TextForId((sender as ImageButton).AlternateText, "answer");
            EditTest.HideField = (sender as ImageButton).AlternateText;
            EditTest.VisibleBtnAnswer = false;
            EditTest.CorrectAnswer = Test.CheckAnswer((sender as ImageButton).AlternateText, "answer");
            EditTest.AnswerPanel = true;
            EditTest.btnRedactAnswer = true;
            EditTest.Visible = true;
        }

        protected void Finish_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/profile/Teacher/yourTests.aspx");            
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void RedactTestName_Click(object sender, EventArgs e) {
            EditTest.HideField = test_id.Value;
            EditTest.HeaderToControl = "Редактирование";
            EditTest.TextControl = "Название теста: ";
            EditTest.Text = Test.TestName(test_id.Value);
            EditTest.VisibleBtnTest = true;            
            EditTest.Visible = true;
        }              
    }
}