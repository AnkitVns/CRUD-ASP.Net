using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace DemoApp.Models
{
    public static class Connection
    {

        public static SqlConnection getConnection()
        {
            SqlConnection cn = new SqlConnection(@"Data Source=ANKIT\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Test");
            return cn;
        }
    }
}