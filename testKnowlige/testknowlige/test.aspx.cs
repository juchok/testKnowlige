using System;
using TestKnowlige.classes;
namespace TestKnowlige
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"])) {
                test_id.Value = Request.QueryString["id"];
                try
                {
                    header_discipline.Text = "Дисциплина: " + Discipliness.DisciplineForTest(Request.QueryString["id"]);
                    header_categories.Text = "Категория: " + Categorieses.CategoriesForTest(Request.QueryString["id"]);
                    header_test.Text = "Тест: " + Test.TestName(Request.QueryString["id"]);
                    Test.QuestionsBind(questions, test_id.Value);
                }
                catch (Exception ex)
                {
                    MessageError.Text = ex.Message;
                    MessageError.Visible = true;
                }                
            }
             else {
                // если тут стоит редирект на главную страничку в случае если нет get параметра id то выскакивает ошибка:
                //PreviousPage	"PreviousPage" запустило исключение типа "System.Threading.ThreadAbortException"	System.Web.UI.Page {System.Threading.ThreadAbortException}
                //на стронице testcomplite.aspx куда передаем post методом страничку с завершенным методом для обработки результата
                //Response.Redirect("~/default.aspx");
                MessageError.Text = "Ну указан тест который хотите пройти. Вернитесь на главную страницу и выбирите тест";
                MessageError.Visible = true;
                Complite.Visible = false;
                lnkHome.Visible = true;
            }
        }               
    }
}