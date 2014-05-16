using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace TestKnowlige.classes
{
    public class SelectItem
    {
        public static bool Discipline(Repeater userControl){
            if (Discipline(userControl, "select discipline_name from discipline")) {
                return true;
            }
            return false;
        }

        public static bool Discipline(Repeater userControl, string command) {
            SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, command);
            if (!Count(command))
            {
                return false;
            }
            try
            {
                userControl.DataSource = ds;
                userControl.DataBind();
                return true;                
            }
            catch (Exception)
            {
                return false;                
            }            
        }

        public static bool Count(string command){
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            SqlCommand cmd = new SqlCommand(command, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) return true;
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool Count(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);            
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) return true;
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool Categories(Repeater userControl) {
            string str = Categories(userControl, "").ToString();
            if (string.IsNullOrEmpty(str)) 
            {
                return true;
            }
            return false;
        }

        public static bool? Categories(Repeater userControl, string getstr)
        {            
            if (string.IsNullOrEmpty(getstr))
            {
                return null;
            }
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);            
            SqlCommand cmd = new SqlCommand("select discipline_id from discipline where Discipline_name = @name", con);
            cmd.Parameters.AddWithValue("name", getstr);
            
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();                
                if (dr.HasRows)
                {
                    string str = "";
                    while (dr.Read()) {
                        str = dr["discipline_id"].ToString();
                        if (!string.IsNullOrEmpty(str))
                            break;
                    }
                    
                    dr.Close();
                    SqlCommand cm = new SqlCommand("select categories_name from categories where discipline_id = @id", con);
                    cm.Parameters.AddWithValue("id", str);
                    dr = cm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, cm.CommandText);
                        ds.SelectParameters.Add("id", str);
                        userControl.DataSource = ds;
                        userControl.DataBind();
                        return true;
                    }
                    
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally {
                con.Close();
            }           
        }

        public static bool? Tests(Repeater UserControl, string cat) {
            if (string.IsNullOrEmpty(cat))
            {
                return null;
            }
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "SELECT DISTINCT t.test_id FROM test_question t INNER JOIN question AS q ON t.question_id = q.question_id" + 
                " INNER JOIN Categories AS c ON c.cat_id = q.cat_id WHERE c.categories_name = @cat_name";            
            SqlDataSource ds = new SqlDataSource(con.ConnectionString, str);            
            ds.SelectParameters.Add("cat_name", cat);            
            try
            {
                UserControl.DataSource = ds;
                UserControl.DataBind();
                if(UserControl.Controls.Count != 0){
                    return true;
                }
            }
            catch (Exception)
            {
                return false;   
            }
            return false;            
        }

        public static string DefaultDiscipline() {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select top(1) discipline_name from discipline";
            SqlCommand cmd = new SqlCommand(str, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return dr["discipline_name"].ToString();
                }
            }
            catch (Exception)
            {
                return "";
            }
            finally {
                con.Close();
            }
            return "";
        }

        public static int DisciplineID(string discipline) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            string str = "select discipline_id from discipline where discipline_name = @name";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("name", discipline);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return int.Parse(dr["discipline_id"].ToString());
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
            return 0;
        }
    }
}