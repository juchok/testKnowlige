using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using TestKnowlige.classes;

namespace TestKnowlige.usercontrol
{
    public partial class AddDicciplineOrCaregories : System.Web.UI.UserControl
    {
        string _header, _author, _discipline, _disOrCat;
        bool _disVis;
        int _discipline_id;

        public int DisciplineId {
            get { return _discipline_id; }
            set
            {
                if (value < 0)
                    _discipline_id = 0;
                else
                    _discipline_id = value;
            }
        }

        public string Header {
            get { return _header; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    _header = "header";
                }
                else {
                    _header = value;
                }
            }
        }

        public string Author {
            get { return _author; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    _author = "Teacher";
                }
                else {
                    _author = value;
                }
            } 
        }

        public string Discipline {
            get { return _discipline; }
            set { _discipline = value;}            
        }

        public string DisciplineOrCategories {
            get { return _disOrCat; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    _disOrCat = "Введите название дисциплины";
                }
                else {
                    _disOrCat = value;
                }
            } 
        }

        public bool DisciplineHide {
            get { return _disVis; }
            set {
                if (bool.Parse(value.ToString()))
                {
                    _disVis = true;
                }
                else {
                    _disVis = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (_disVis)
            {
                discipline.Text = _discipline;
            }
            else {
                discipline.Visible = false;
            }
            HeaderControl.Text = _header;
            lblDisciplineOrCategories.Text = _disOrCat;
            author.Text = _author;
            discipline_id.Value = _discipline_id.ToString();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(discipline_id.Value) == 0)
                {
                    Disciplines.NewDiscipline(txtDisciplineOrCategories.Text, author.Text.Split(':')[1].Trim());
                    (Page.FindControl("DirDiscipline") as Repeater).DataBind();
                }
                else
                {
                    Categorieses.NewCategories(txtDisciplineOrCategories.Text, discipline_id.Value, author.Text.Split(':')[1].Trim());
                    (Page.FindControl("DirCategories") as Repeater).DataBind();
                }
            }
            catch (Exception ex)
            {
                (Page.FindControl("MessageError") as Label).Text = ex.Message;
                (Page.FindControl("MessageError") as Label).Visible = true;
            }
            finally {
                this.Visible = false;                
            }        
        }

    }
}