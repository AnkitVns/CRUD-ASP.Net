using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoApp.Models
{
    public class UpdateModel
    {
        public string studentid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string age { get; set; }
        public string address { get; set; }


        public UpdateModel UpdateStudentRecord(string studentid)
        {
            UpdateModel studentRecords = new UpdateModel();

            SqlConnection cn = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("Select studentid,firstname,lastname,age,address From StudentRecords WHERE studentid='" + studentid + "'", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                studentRecords.studentid = row["studentid"].ToString();
                studentRecords.firstname = row["firstname"].ToString();
                studentRecords.lastname = row["lastname"].ToString();
                studentRecords.age = row["age"].ToString();
                studentRecords.address = row["address"].ToString();
                
            }

            return studentRecords;
        }
    }
}