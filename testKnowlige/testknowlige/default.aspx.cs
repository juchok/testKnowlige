using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using TestKnowlige.classes;
using System.Web.Security;

namespace TestKnowlige
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {                
                if (!string.IsNullOrEmpty(Request.QueryString["Discipline"]))
                {
                    Response.Cookies["Discipline"].Value = Request.QueryString["Discipline"];
                    Response.Cookies["Discipline"].Expires = DateTime.Now.AddDays(1);
                }
                if (!string.IsNullOrEmpty(User.Identity.Name) && MyRoles.IsUserInRole(User.Identity.Name, "Teacher"))
                {
                    addDoC.Visible = true;
                    addCat.Visible = true;
                }
                if (string.IsNullOrEmpty(User.Identity.Name))
                {
                    register.Visible = true;
                }
                else {
                    register.Visible = false;
                }
                if (!SelectItem.Discipline(DirDiscipline, "select discipline_name from discipline"))
                {
                    errDis.Visible = true;
                }
                                
                string str = SelectItem.Categories(DirCategories, Request.QueryString["Discipline"]).ToString();

                if (string.IsNullOrEmpty(str))
                {
                    SelectDiscipline.Visible = true;
                }
                else
                    if (str.ToLower() == "false")
                    {
                        errCat.Visible = true;
                    }

                str = SelectItem.Tests(DirTests, Request.QueryString["categories"]).ToString();

                if (string.IsNullOrEmpty(str))
                {
                    selectCategories.Visible = true;
                }
                else
                    if (str.ToLower() == "false")
                    {
                        errTests.Visible = true;
                    }

                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    lnkChangePass.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ErrorMes.ErrorHeader = ex.Source;
                ErrorMes.MesError = ex.Message;
                ErrorMes.Visible = true;
            }            
        }

        protected void addDoC_Click(object sender, EventArgs e)
        {

            if ((sender as ImageButton).AlternateText == "addDis") {
                addNewItem.Header = "Добавить дисциплину";
                addNewItem.DisciplineHide = false;
                addNewItem.DisciplineOrCategories = "Введите название дисциплины";
                addNewItem.Author = "Автор: " + User.Identity.Name;
                addNewItem.Visible = true;
            }
            if ((sender as ImageButton).AlternateText == "addCat")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["discipline"]))
                {
                    addNewItem.Header = "Добавить категорию";
                    addNewItem.DisciplineHide = true;
                    addNewItem.Discipline = "Дисциплина: " + Request.QueryString["discipline"];
                    addNewItem.DisciplineOrCategories = "Введите название категории";
                    addNewItem.Author = "Автор: " + User.Identity.Name;
                    addNewItem.DisciplineId = SelectItem.DisciplineID(Request.QueryString["discipline"]);
                    addNewItem.Visible = true;
                }
                else {
                    ErrorMes.ErrorHeader = "Ошибочка";
                    ErrorMes.MesError = "Для того что бы добавить категорию необходимо выбрать дисциплину!";
                    ErrorMes.Visible = true;
                }
            }
            if ((sender as ImageButton).AlternateText == "addTest") { 
                Response.Redirect("~/addTest.aspx");
            }
        }

        protected void Page_PreInit(object sender, EventArgs e) {
            
        }
    }
}