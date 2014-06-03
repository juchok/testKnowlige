using System;
using System.Web.UI.WebControls;
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
                if (!string.IsNullOrEmpty(User.Identity.Name) &&( Roles.IsUserInRole(User.Identity.Name, "Teacher") || Roles.IsUserInRole(User.Identity.Name, "Admin")))
                {
                    addDoC.Visible = true;
                    addCat.Visible = true;
                    addTest.Visible = true;
                }
                if (string.IsNullOrEmpty(User.Identity.Name))
                {
                    register.Visible = true;
                }
                else {
                    register.Visible = false;
                }
                if (!Discipliness.Discipline(DirDiscipline, "select discipline_name from discipline"))
                {
                    errDis.Visible = true;
                }
                                
                string str = Categorieses.Categories(DirCategories, Request.QueryString["Discipline"]).ToString();

                if (string.IsNullOrEmpty(str))
                {
                    SelectDiscipline.Visible = true;
                }
                else
                    if (str.ToLower() == "false")
                    {
                        errCat.Visible = true;
                    }

                str = Test.Tests(DirTests, Request.QueryString["categories"]).ToString();

                if (string.IsNullOrEmpty(str))
                {
                    selectCategories.Visible = true;
                }
                else
                    if (str.ToLower() == "false")
                    {
                        errTests.Visible = true;
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
                    try
                    {
                        addNewItem.DisciplineId = int.Parse(Discipliness.DisciplineId(Request.QueryString["discipline"]));
                        addNewItem.Visible = true;
                    }
                    catch (Exception ex) {
                        MessageError.Text = ex.Message;
                        MessageError.Visible = true;
                    }                    
                }
                else {
                    ErrorMes.ErrorHeader = "Ошибочка";
                    ErrorMes.MesError = "Для того что бы добавить категорию необходимо выбрать дисциплину!";
                    ErrorMes.Visible = true;
                }
            }
            if ((sender as ImageButton).AlternateText == "addTest")            
            {
                if (!string.IsNullOrEmpty(Request.QueryString["categories"]))
                {
                    Response.Cookies["categories"].Value = Request.QueryString["categories"];
                    try
                    {
                        Response.Redirect("~/addTest.aspx?cat=" + Categorieses.CategoriesId(Request.QueryString["categories"]));
                    }
                    catch (Exception ex)
                    {
                        MessageError.Text = ex.Message;
                        MessageError.Visible = true;
                    }                    
                }
                else
                {
                    ErrorMes.ErrorHeader = "Ошибочка";
                    ErrorMes.MesError = "Для того что бы добавить тест необходимо выбрать категорию!";
                    ErrorMes.Visible = true;
                }
            }            
        }                
    }
}