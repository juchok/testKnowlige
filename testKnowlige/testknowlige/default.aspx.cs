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
            string cock;
            if (!string.IsNullOrEmpty(Request.QueryString["Discipline"])) {
                //HttpCookie aCookie = new HttpCookie("userInfo");
                //aCookie.Values["userName"] = "patrick";
                //aCookie.Values["lastVisit"] = DateTime.Now.ToString();
                //aCookie.Expires = DateTime.Now.AddDays(1);
                //Response.Cookies.Add(aCookie);

                //http://msdn.microsoft.com/ru-ru/library/ms178194%28v=vs.100%29.aspx

                HttpCookie aCookie = new HttpCookie("Discipline");
                aCookie.Value = Request.QueryString["Discipline"];
                aCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(aCookie);

                //Response.Cookies["Discipline"].Value = Request.QueryString["Discipline"];                
            }
            if (Roles.IsUserInRole(User.Identity.Name, "Teacher"))
                addDoC.Visible = true;
            if (!SelectItem.Discipline(DirDiscipline, "select discipline_name from discipline"))            
            {
                errDis.Visible = true;
            }

            if (string.IsNullOrEmpty(Request.QueryString["Discipline"]))
            {
                cock = Server.HtmlEncode(Response.Cookies["Discipline"].Value);
            }
            else {
                cock = Request.QueryString["Discipline"];
            }
            string str = SelectItem.Categories(DirCategories, cock).ToString();

            if (string.IsNullOrEmpty(str)) {
                SelectDiscipline.Visible = true;
            }else 
                if (str.ToLower()=="false")
                {
                    errCat.Visible = true;
                }

            if (string.IsNullOrEmpty(Request.QueryString["categories"]))
            {
                cock = Server.HtmlEncode(Response.Cookies["categories"].Value);
            }
            else {
                cock = Request.QueryString["categories"];
            }

            str = SelectItem.Tests(DirTests, cock).ToString();

            if (string.IsNullOrEmpty(str)) {
                selectCategories.Visible = true;
            }else 
                if (str.ToLower() == "false")
                {
                    errTests.Visible = true;
                }
            
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                lnkChangePass.Visible = true;
            }            
        }

        protected void addDoC_Click(object sender, EventArgs e)
        {

            if ((sender as ImageButton).AlternateText == "addDis") {
                addNewItem.Header = "Добавить дисциплину";
                addNewItem.DisciplineHide = false;
                addNewItem.DisciplineOrCategories = "Введите название дисциплины";
                addNewItem.Author = User.Identity.Name;
            }
            if ((sender as ImageButton).AlternateText == "addCat")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["discipline"])){
                    addNewItem.Header = "Добавить категорию";
                    addNewItem.DisciplineHide = true;                
                    addNewItem.Discipline = "Дисциплина: " + Request.QueryString["discipline"];                
                    addNewItem.DisciplineOrCategories = "Введите название категории";
                    addNewItem.Author = User.Identity.Name;
                }

            }
        }
    }
}