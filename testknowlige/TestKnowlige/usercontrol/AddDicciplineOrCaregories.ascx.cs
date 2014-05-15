using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestKnowlige.usercontrol
{
    public partial class AddDicciplineOrCaregories : System.Web.UI.UserControl
    {
        public string Header {
            get { return HeaderControl.Text; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    HeaderControl.Text = "header";
                }
                else {
                    HeaderControl.Text = value;
                }
            }
        }

        public string Author {
            get { return author.Text; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    author.Text = "Teacher";
                }
                else {
                    author.Text = value;
                }
            } 
        }

        public string Discipline {
            get { return discipline.Text; }
            set { discipline.Text = value;}            
        }

        public string DisciplineOrCategories {
            get { return lblDisciplineOrCategories.Text; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    lblDisciplineOrCategories.Text = "Введите название дисциплины";
                }
                else {
                    lblDisciplineOrCategories.Text = value;
                }
            } 
        }

        public bool DisciplineHide {
            get { return discipline.Visible; }
            set {
                if (bool.Parse(value.ToString()))
                {
                    discipline.Visible = true;
                }
                else {
                    discipline.Visible = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}