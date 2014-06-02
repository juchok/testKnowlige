using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestKnowlige.classes;

namespace TestKnowlige.usercontrol
{
    public partial class TestRedact : System.Web.UI.UserControl
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
            RedactTestName.Visible = _btnTest;
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
            try
            {
                Test.AddQuestion(txtAdd.Text, txtPoints.Text, Page.User.Identity.Name, (Page.FindControl("test_id") as HiddenField).Value);
            }
            catch (Exception ex) { 
                (Page.FindControl("MessageError") as Label).Text = ex.Message;
                (Page.FindControl("MessageError") as Label).Visible = true;
            }
            
            Test.TestBind(Page);
            this.Visible = false;
            SaveComplite();
        }

        protected void btnAddAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                Test.AddAnswer(hideField.Value, txtAdd.Text, ckbCorrect.Checked);
            }
            catch (Exception ex) {
                (Page.FindControl("MessageError") as Label).Text = ex.Message;
                (Page.FindControl("MessageError") as Label).Visible = true;
            }
            
            this.Visible = false;            
            Test.TestBind(Page);
            SaveComplite();
        }
                

        protected void RedactQuestion_Click(object sender, EventArgs e) {
            Test.UpdateQuestion(hideField.Value, txtAdd.Text, txtPoints.Text);
            Test.TestBind(Page);
            this.Visible = false;
            SaveComplite();
        }

        protected void RedactAnswer_Click(object sender, EventArgs e) {
            Test.UpdateAnswer(hideField.Value, txtAdd.Text, ckbCorrect.Checked);
            Test.TestBind(Page);
            this.Visible = false;
            SaveComplite();
        }

        protected void SaveComplite() {
            string str = "$('.saveComplite').show().animate({'opacity':'0.1'},100).animate({'opacity':'0.8'},100).animate({'opacity':'0.1'},100).animate({'opacity':'0.8'},100).animate({'opacity':'0.1'},100).animate({'opacity':'0.8'},100).fadeOut()";
            Page.ClientScript.RegisterStartupScript(GetType(), "savecomplite", str, true);
        }

        protected void RedactTestName_Click(object sender, EventArgs e) {
            Test.UpdateTestName(hideField.Value, txtAdd.Text);
            Test.TestNameBind(Page);
            this.Visible = false;
            SaveComplite();
        }
    }
}