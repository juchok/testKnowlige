﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TestKnowlige.classes
{
    public class LoGiN
    {
        public static bool CheckUser(string log, string password) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
            string str = "select firstname from users where login='"+log+"' and password='"+password.GetHashCode().ToString()+"'";
            SqlCommand cmd = new SqlCommand(str, con);
            try
            {
                con.Open();
                if (!cmd.ExecuteReader().HasRows) return false;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                con.Close();
            }
        }

        public static bool CheckLogin(string login) {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
            string str = "select firstname from users where login=@login";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("login", login);
            try
            {
                con.Open();
                if (!cmd.ExecuteReader().HasRows) return false;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}