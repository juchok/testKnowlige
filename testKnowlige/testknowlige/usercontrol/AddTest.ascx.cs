using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Configuration;
using System.Data.SqlClient;
using TestKnowlige.classes;

namespace TestKnowlige.usercontrol
{
    public partial class AddTest : System.Web.UI.UserControl
    {
        string _header = "Новый тест", _text = "Введите название теста", _hide, _txtValue, _txtPoints;
        bool _btnTest, _btnQuestion, _btnAnswer, _questionpanel, _answerpanel, _redactAnswer, _redactQuestion;
        bool _checkAnswer;

        public string Points {
            get { return _txtPoints; }
            set { _txtPoints = value; }
        }

        public bool CorrectAnswer {
            get
            {
                return _checkAnswer;
            }
            set { _checkAnswer = value; } 
        }

        public string Text {
            get { return _txtValue; }
            set {_txtValue = value;} 
        }

        public bool btnRedactQuestion {
            get { return _redactQuestion; }
            set { _redactQuestion = value; }
        }

        public bool btnRedactAnswer {
            get { return _redactAnswer; }
            set { _redactAnswer = value; }
        }

        public bool QuestionPanel {
            get { return _questionpanel; }
            set { _questionpanel = value; } 
        }

        public bool AnswerPanel {
            get { return _answerpanel; }
            set { _answerpanel = value; } 
        }

        public string HeaderToControl {
            get { return _header; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    _header = "Добавить";
                }
                else {
                    _header = value;
                }
            } 
        }

        public string TextControl {
            get { return _text; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    _text = "Введите название";
                }
                else {
                    _text = value;
                }
            }
        }

        public string HideField {
            get { return _hide; }
            set { _hide = value;}
        }

        public bool VisibleBtnTest {
            get
            {
                return _btnTest;
            }
            set {
                _btnTest = value;
            } 
        }

        public bool VisibleBtnQuestion {
            get { return _btnQuestion; }
            set { _btnQuestion = value; }
        }

        public bool VisibleBtnAnswer
        {
            get { return _btnAnswer; }
            set { _btnAnswer = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        protected void Page_PreRender(object sender, EventArgs e) {
            HeaderControl.Text = _header;
            lblAdd.Text = _text;
            hideField.Value = _hide;
            btnAddAnswer.Visible = _btnAnswer;
            btnAddQuestion.Visible = _btnQuestion;
            btnAddTest.Visible = _btnTest;
            txtAdd.Text = _txtValue;
            question_points.Visible = _questionpanel;
            answer_correct.Visible = _answerpanel;
            RedactAnswer.Visible = _redactAnswer;
            RedactQuestion.Visible = _redactQuestion;
            ckbCorrect.Checked = _checkAnswer;
            txtPoints.Text = _txtPoints;
        }

        protected void btnAddQuestion_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "insert into tempquestions (text, points, test_id) values (@text, @points, @id)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("text",txtAdd.Text);
            cmd.Parameters.AddWithValue("points", txtPoints.Text);
            cmd.Parameters.AddWithValue("id", (Page.FindControl("test_id") as HiddenField).Value);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                con.Close();
            }

            Test.AnswerBind(Page);
            this.Visible = false;
        }

        protected void btnAddAnswer_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "insert into tempanswer (question_id, text, correct) values (@id, @text, @cur)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("id", hideField.Value);
            cmd.Parameters.AddWithValue("text", txtAdd.Text);
            cmd.Parameters.AddWithValue("cur", ckbCorrect.Checked);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
            this.Visible = false;

            Test.AnswerBind(Page);
        }

        protected void btnAddTest_Click(object sender, EventArgs e)
        {            
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "insert into temptest (name, user_id, cat_id) values (@name, @id, @cat_id)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("name", txtAdd.Text);
            cmd.Parameters.AddWithValue("id", LoGiN.UserId(HttpContext.Current.User.Identity.Name));
            cmd.Parameters.AddWithValue("cat_id", (Page.FindControl("cat_id") as HiddenField).Value);
            (Page.FindControl("testName") as Label).Text = "Тест: " + txtAdd.Text;
            this.Visible = false;
            (Page.FindControl("addNewTest") as ImageButton).Visible = false;
            (Page.FindControl("AddQuestion") as ImageButton).Visible = true;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }

            (Page.FindControl("save") as Button).Visible = true;

            (Page.FindControl("test_id") as HiddenField).Value = Test.AddTestId(txtAdd.Text).ToString();
            Test.AnswerBind(Page);
        }

        protected void RedactQuestion_Click(object sender, EventArgs e) {
            Test.UpdateTempQuestion(hideField.Value, txtAdd.Text, txtPoints.Text);
            Test.AnswerBind(Page);
            this.Visible = false;
        }

        protected void RedactAnswer_Click(object sender, EventArgs e) {
            Test.UpdateTempAnswer(hideField.Value, txtAdd.Text, ckbCorrect.Checked);
            Test.AnswerBind(Page);
            this.Visible = false;
        }
    }
}