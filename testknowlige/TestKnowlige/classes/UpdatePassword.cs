﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TestKnowlige.classes
{
    public class UpdatePassword
    {
        public static bool update(string pass, string login) {           
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                string str = "update users set password = '" + pass.GetHashCode().ToString() + "' where login='" + login + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                try
                {
                    con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                        return true;
                    return false;
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