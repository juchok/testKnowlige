using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            try
            {
                Test.AddTempQuestion(txtAdd.Text, txtPoints.Text, (Page.FindControl("test_id") as HiddenField).Value);
                Test.AnswerBind(Page);
                this.Visible = false;
            }
            catch (Exception ex) {
                (Page.FindControl("MessageError") as Label).Text = ex.Message;
                (Page.FindControl("MessageError") as Label).Visible = true;
            }            
        }

        protected void btnAddAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                Test.AddTempAnswer(hideField.Value, txtAdd.Text, ckbCorrect.Checked);
                this.Visible = false;
                Test.AnswerBind(Page);
            }
            catch (Exception ex) {
                (Page.FindControl("MessageError") as Label).Text = ex.Message;
                (Page.FindControl("MessageError") as Label).Visible = true;
            }            
        }

        protected void btnAddTest_Click(object sender, EventArgs e)
        {
            try
            {
                Test.AddTempTest(txtAdd.Text, HttpContext.Current.User.Identity.Name, (Page.FindControl("cat_id") as HiddenField).Value);

                this.Visible = false;
                (Page.FindControl("testName") as Label).Text = "Тест: " + txtAdd.Text;                
                (Page.FindControl("addNewTest") as ImageButton).Visible = false;
                (Page.FindControl("AddQuestion") as ImageButton).Visible = true;
                (Page.FindControl("save") as Button).Visible = true;
                (Page.FindControl("test_id") as HiddenField).Value = Test.AddTestId(txtAdd.Text).ToString();
                Test.AnswerBind(Page);
            }
            catch (Exception ex) {
                (Page.FindControl("MessageError") as Label).Text = ex.Message;
                (Page.FindControl("MessageError") as Label).Visible = true;
            }
        }

        protected void RedactQuestion_Click(object sender, EventArgs e) {
            try
            {
                Test.UpdateTempQuestion(hideField.Value, txtAdd.Text, txtPoints.Text);
                Test.AnswerBind(Page);
                this.Visible = false;
            }
            catch (Exception ex)
            {
                (Page.FindControl("MessageError") as Label).Text = ex.Message;
                (Page.FindControl("MessageError") as Label).Visible = true;
            }
        }

        protected void RedactAnswer_Click(object sender, EventArgs e) {
            try
            {
                Test.UpdateTempAnswer(hideField.Value, txtAdd.Text, ckbCorrect.Checked);
                Test.AnswerBind(Page);
                this.Visible = false;
            }
            catch (Exception ex)
            {
                (Page.FindControl("MessageError") as Label).Text = ex.Message;
                (Page.FindControl("MessageError") as Label).Visible = true;
            }
        }
    }
}