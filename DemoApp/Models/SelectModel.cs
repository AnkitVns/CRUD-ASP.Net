using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoApp.Models
{
    public class SelectModel
    {
        public string studentid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string age { get; set; }
        public string address { get; set; }
        

        public List<SelectModel> fetch_data()
        {
            List<SelectModel> list = new List<SelectModel>();

            SqlConnection cn = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("Select studentid,firstname,lastname,age,address From StudentRecords", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                var data = new SelectModel();
                data.studentid = row["studentid"].ToString();
                data.firstname = row["firstname"].ToString();
                data.lastname = row["lastname"].ToString();
                data.age = row["age"].ToString();
                data.address = row["address"].ToString();
                
                list.Add(data);
            }
            return list;
        }
    }
}