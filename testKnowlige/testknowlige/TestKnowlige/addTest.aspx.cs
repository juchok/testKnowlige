using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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
            }
            if (!string.IsNullOrEmpty(test_id.Value))
            {
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

                string str = "select text, points, question_id from tempquestions where test_id = @id";
                SqlDataSource ds= new SqlDataSource(con.ConnectionString, str);
                ds.SelectParameters.Add("id", test_id.Value);

                questions.DataSource = ds;
                questions.DataBind();

                int i = 0;
                foreach (RepeaterItem item in questions.Items)
                {
                    Repeater answer = (Repeater)questions.Items[i].FindControl("answers");
                    string id = (item.FindControl("question_id") as HiddenField).Value;
                    str = "select answer_text from tempanswer where question_id = @id";
                    SqlDataSource ds1 = new SqlDataSource(con.ConnectionString, str);
                    ds1.SelectParameters.Add("id", id);
                    answer.DataSource = ds1;
                    answer.DataBind();
                    i++;
                }
            }

        }

        protected void addTest_Click(object sender, ImageClickEventArgs e)
        {
            defaultButton();            
        }

        protected void AddAnswer_Click(object sender, ImageClickEventArgs e)
        {
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

        protected void AddBtn_Click(object sender, ImageClickEventArgs e) 
        { 

        }
    }
}