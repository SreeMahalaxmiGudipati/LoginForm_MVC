using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Login_MVC_.Models;
using System.Web.Mvc;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace Login_MVC_.Controllers
{
    public class AccountController : Controller
    {

        SqlConnection conn=new SqlConnection();
        SqlCommand cmd=new SqlCommand();
        SqlDataReader sdr;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
       
        void connectionString()
        {
            conn.ConnectionString = "Data Source=(localdb)\\Local;Initial Catalog=LoginDB;Integrated Security=True";
        }
        [HttpPost]
        public ActionResult Verify(Account ac)
        {
            connectionString();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select * from LoginForm where Username='"+ac.Username+ "' and Password='"+ac.Password+"' ";
            sdr = cmd.ExecuteReader();
            if(sdr.Read())
            {
                conn.Close();
                return View("Create");
            }
            else
            {
                conn.Close();
                return View("Error");
            }
            
            
        }
    }
}