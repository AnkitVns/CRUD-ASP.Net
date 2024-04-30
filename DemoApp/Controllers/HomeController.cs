using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoApp.Models;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Collections;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // Add
        public ActionResult Add()
        {
            return View();
        }

        // Update
        public ActionResult Update(string studentid)
        {
            TempData["studentid"] = studentid;
            return View();
        }


        //Fetch_StudentRecords
        public string getData()
        {
            SelectModel ret = new SelectModel();
            var jsonSerialiser = new JavaScriptSerializer();
            return jsonSerialiser.Serialize(ret.fetch_data());
        }

        // Insert_StudentRecord
        public string insertdata(string firstname, string lastname, string age, string address)
        {
            SqlConnection cn = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("Insert Into StudentRecords(firstname,lastname,age,address)Values('" + firstname + "','" + lastname + "','" + Convert.ToInt64(age) + "','" + address + "')", cn);
            cn.Open();
            var val = cmd.ExecuteNonQuery();
            cn.Close();
            string value = "0";
            value = ("/Home/Index");
            return value;
        }
        
        //Update_Select_StudentRecords
        public string updateData()
        {
            var studentid = TempData["studentid"];
            UpdateModel updateModule = new UpdateModel();
            var jsonSerialiser = new JavaScriptSerializer();
            return jsonSerialiser.Serialize(updateModule.UpdateStudentRecord(studentid.ToString()));
        }

        // Update_Set_StudentRecords
        public string Update_Data(string studentid, string firstname, string lastname, string age, string address)
        {
            SqlConnection cn = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("Update StudentRecords set firstname='" + firstname + "',lastname='" + lastname + "',age='" + age + "',address='" + address + "' where studentid='" + studentid + "'", cn);
            cn.Open();
            var val = cmd.ExecuteNonQuery();
            cn.Close();
            string value = "0";
            value = ("/Home/Index");
            return value;
        }

        //Delete_StudentRecords
        public string deletedata(string studentid)
        {
            SqlConnection cn = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM StudentRecords WHERE studentid='" + studentid + "'", cn);
            cn.Open();
            var val = cmd.ExecuteNonQuery();
            cn.Close();
            string value = "0";
            value = ("/Home/Index");
            return value;
        }

    }
}  