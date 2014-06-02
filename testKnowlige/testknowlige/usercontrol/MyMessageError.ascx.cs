using System;

namespace TestKnowlige.usercontrol
{
    public partial class MyMessageError : System.Web.UI.UserControl
    {
        string _header, _error;

        public string ErrorHeader {
            get { return _header; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    _header = "Упс... Ошибочка";
                }
                else {
                    _header = value;
                }
                }
            }

        public string MesError {
            get { return _error; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    _error = "Непонятная ошибочка";
                }
                else {
                    _error = value;
                }
            } 
        }



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e) {
            HeaderControl.Text = _header;
            ErrorMes.Text = _error;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}