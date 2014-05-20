using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using TestKnowlige.classes;

namespace TestKnowlige
{
    public partial class addTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                testAuthor.Text = "Автор: " + User.Identity.Name;                
                defaultButton();
                addNewTest.Visible = true;
                if (!string.IsNullOrEmpty(Request.Cookies["categories"].Value)) { 
                    cat_id.Value = Test.CategoriesId(Request.Cookies["categories"].Value).ToString();
                }                
            }
            if (!string.IsNullOrEmpty(test_id.Value))
            {
                Test.AnswerBind(Page);
            }
        }

        protected void addTest_Click(object sender, ImageClickEventArgs e)
        {
            defaultButton();            
        }

        protected void AddAnswer_Click(object sender, ImageClickEventArgs e)
        {
            NewTest.HideField = (sender as ImageButton).AlternateText;
            NewTest.HeaderToControl = "Добавить ответ";
            NewTest.TextControl = "Введите текст ответа";
            NewTest.VisibleBtnAnswer = true;
            NewTest.AnswerPanel = true;
            NewTest.Visible = true;
        }

        protected void AddQuestion_Click(object sender, ImageClickEventArgs e)
        {
            NewTest.HeaderToControl = "Новый вопрос";
            NewTest.TextControl = "Введите текст вопроса";
            NewTest.VisibleBtnQuestion = true;
            NewTest.QuestionPanel = true;
            NewTest.Visible = true;
        }

        private void defaultButton() {
            NewTest.HeaderToControl = "Новый тест";
            NewTest.TextControl = "Введите название теста";
            NewTest.VisibleBtnTest = true;
            NewTest.Visible = true;            
        }

        protected void delQuestion_Click(object sender, ImageClickEventArgs e) 
        {
            FormConfirm.Text = "Вопрос: " + Test.TextForId((sender as ImageButton).AlternateText, "tempquestions");
            FormConfirm.DelMessage = "Вы действительно хотите удалить вопрос?";
            FormConfirm.btnDelQuestion = true;
            FormConfirm.Id = (sender as ImageButton).AlternateText;
            FormConfirm.Visible = true;
        }

        protected void delAnswer_Click(object sender, ImageClickEventArgs e)
        {
            FormConfirm.Text = "Ответ: " + Test.TextForId((sender as ImageButton).AlternateText, "tempanswer");
            FormConfirm.DelMessage = "Вы действительно хотите удалить ответ?";
            FormConfirm.btnDelAnswer = true;
            FormConfirm.Id = (sender as ImageButton).AlternateText;
            FormConfirm.Visible = true;            
        }

        protected void RedactQuestion_Click(object sender, ImageClickEventArgs e) {
            NewTest.HeaderToControl = "Редактирование";
            NewTest.TextControl = "Введите текст вопроса";
            NewTest.Text = Test.TextForId((sender as ImageButton).AlternateText, "tempquestions");
            NewTest.Points = Test.PointsToQuestion((sender as ImageButton).AlternateText);
            NewTest.HideField = (sender as ImageButton).AlternateText;            
            NewTest.QuestionPanel = true;
            NewTest.VisibleBtnQuestion = false;
            NewTest.btnRedactQuestion = true;
            NewTest.Visible = true;
        }

        protected void RedactAnswer_Click(object sender, ImageClickEventArgs e) {
            NewTest.HideField = (sender as ImageButton).AlternateText;
            NewTest.HeaderToControl = "Редактирование";
            NewTest.TextControl = "Введите текст ответа";
            NewTest.Text = Test.TextForId((sender as ImageButton).AlternateText, "tempanswer");
            NewTest.HideField = (sender as ImageButton).AlternateText;
            NewTest.VisibleBtnAnswer = false;
            NewTest.CorrectAnswer = Test.CheckTempAnswer((sender as ImageButton).AlternateText);
            NewTest.AnswerPanel = true;
            NewTest.btnRedactAnswer = true;
            NewTest.Visible = true;
        }

        protected void save_Click(object sender, EventArgs e)
        {
            int userId = LoGiN.UserId(User.Identity.Name);
            Test.CopyTempTest(test_id.Value, userId.ToString());
            Test.DeleteTempTest(test_id.Value);
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

    }
}