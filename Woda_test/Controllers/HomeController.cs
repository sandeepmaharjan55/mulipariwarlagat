using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Woda_test.Models;

namespace Woda_test.Controllers
{
    public class HomeController : Controller
    {
        private woda_testEntities db = new woda_testEntities();

        // GET: seniordetails
        public ActionResult Index(string q, string order)
        {
            var name = from n in db.table_house_senior_details select n;
            if (q != null)
            {
                name = name.Where(n => n.Name.Contains(q));
            }
            switch (order)
            {
                case "name":
                    name = name.OrderBy(n => n.Name);
                    break;
                case "home":
                    name = name.OrderBy(n => n.Home_no);
                    break;
                default:
                    name = name.OrderBy(n => n.senior_id);
                    break;
            }
            return View(name.ToList());
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}