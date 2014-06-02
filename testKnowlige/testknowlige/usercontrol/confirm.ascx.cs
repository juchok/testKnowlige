using System;
using TestKnowlige.classes;

namespace TestKnowlige.usercontrol
{
    public partial class confirm : System.Web.UI.UserControl
    {
        string _text, _del, _id;
        bool _btnDelAnswer, _btnDelQuestion;

        public string Text {
            get { return _text; }
            set { _text = value; } 
        }

        public string DelMessage {
            get { return _del; }
            set { _del = value;} 
        }

        public string Id {
            get { return _id; }
            set { _id = value; } 
        }
                
        public bool btnDelAnswer {
            get { return _btnDelAnswer; }
            set { _btnDelAnswer = value; } 
        }

        public bool btnDelQuestion {
            get { return _btnDelQuestion; }
            set { _btnDelQuestion = value; } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {            
            this.Visible = false;
        }

        protected void Page_PreRender(object sender, EventArgs e) {
            ConfirgText.Text = _text;
            Confirmdel.Text = _del;
            hideid.Value = _id;            
            ConfirmDeleteAnswer.Visible = _btnDelAnswer;
            ConfirmDeleteQuestion.Visible = _btnDelQuestion;
        }

        protected void ConfirmDeleteQuestion_Click(object sender, EventArgs e)
        {
            Test.DelTempQuestion(hideid.Value);
            Test.AnswerBind(Page);
            this.Visible = false;
        }

        protected void ConfirmDeleteAnswer_Click(object sender, EventArgs e)
        {
            Test.DelTempAnswer(hideid.Value);
            Test.AnswerBind(Page);
            this.Visible = false;
        }
    }
}