using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Mvc;
using All.Models;

namespace All.Controllers
{
    public class MadhanController : Controller
    {

        // GET: Madhan

        //(This is for Enter and Stored Values in Database)
        public ActionResult Display()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Display(Table db)
        {
            if (ModelState.IsValid)
            {
                Database1Entities dbt = new Database1Entities();
                dbt.Tables.Add(db);
                dbt.SaveChanges();
                return RedirectToAction("Validate");
            }
            return View();
        }
        //(This is for Validate from Database)
        public ActionResult Validate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Validate(Table ta)
        {
            if (ModelState.IsValid)
            {
                using (Database1Entities dbs = new Database1Entities())
                {
                    var s = dbs.Tables.Where(x => x.Name.Equals(ta.Name) && x.Phone.Equals(ta.Phone)).FirstOrDefault();
                    if (s != null)
                    {
                        Session["an"] = s.Name;
                        Session["ap"] = s.Phone;
                        return RedirectToAction("List");
                    }
                    else
                    {
                        ViewBag.Message = "REGISTER PLEASE";
                        return View();
                    }
                }
            }
            return View();
        }
        //(This is for list the database data)
        public ActionResult List()
        {
            return View();
        }
        [HttpGet]
        public ActionResult List(string ab)
        {
            Database1Entities dbc = new Database1Entities();
            List<Table> l = dbc.Tables.ToList();
            return View(l);

        }
                           //(This is for show 2 models in a view)
        public ActionResult Twomodel()
        {
            ViewBag.Table = tab();
            ViewBag.Table1 = ta();
            return View();
        }
        [HttpGet]
        public List<Table> tab()
        {
            List<Table> t = new List<Table>();
            Database1Entities db = new Database1Entities();
            db.Tables.ToList();
            DataTable dt = new DataTable();
            foreach (DataRow dr in dt.Rows)
            {
                Table t1 = new Table();
                t1.Id = Convert.ToInt32(dr["Id"].ToString());
                t1.Name = dr["Name"].ToString();
                t1.Address = dr["Address"].ToString();
                t1.Phone = dr["Phone"].ToString();
                t1.DOB = Convert.ToDateTime(dr["DOB"].ToString());
                t.Add(t1);
            }
            return t;
        }
        [HttpGet]

        public  List<Table1> ta()
        {
            List<Table1> tt = new List<Table1>();
            Database1Entities dc = new Database1Entities();
            dc.Table1.ToList();
            DataTable dt = new DataTable();
            foreach(DataRow dr in dt.Rows)
            {
                Table1 t2 = new Table1();
                t2.SId = Convert.ToInt32(dr["SId"].ToString());
                t2.Name = dr["Name"].ToString();
                t2.Phone = dr["Phone"].ToString();
                t2.Id = Convert.ToInt32(dr["Id"].ToString());
                tt.Add(t2);
            }
            return tt;
        }
    
        public ActionResult Rate()
        {
            return View();
        }
    }
}