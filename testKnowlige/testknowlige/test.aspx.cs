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
                 Response.Redirect("~/default.aspx");
            }
        }               
    }
}