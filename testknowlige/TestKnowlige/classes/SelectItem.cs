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
        public static void Discipline(Repeater userControl){
            SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "select discipline_name from discipline");            
            userControl.DataSource = ds;
            userControl.DataBind();            
        }

        public static void Discipline(Repeater userControl, string command) {
            SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, command);
            userControl.DataSource = ds;
            userControl.DataBind();
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
            finally {
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

        public static bool DefaultCategories(Repeater userControl)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select top(1) discipline_id from discipline", con);            
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();       
                    string str = dr["discipline_id"].ToString();
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

        public static string DefaultDiscipline() { 
            
        }

    }
}