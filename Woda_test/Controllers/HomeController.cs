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
        public ActionResult Index()
        {
            var home = db.table_house_senior_details.Include(t => t.table_demographic);
            return View(home.ToList());
            //var name = from n in db.table_house_senior_details.Include(b => b.table_demographic) select n;
            //  var blogs1 = db.table_house_senior_details
            //             .Include(b => b.table_demographic)
            //             .ToList();
            //if (q != null)
            //{
            //  name = name.Where(n => n.Name.Contains(q));
            //}
            //switch (order)
            //{
            //  case "name":
            //    name = name.OrderBy(n => n.Name);
            //  break;
            //case "home":
            //   name = name.OrderBy(n => n.Home_no);
            //  break;
            //default:
            //  name = name.OrderBy(n => n.senior_id);
            //  break;
        
          //  return View(name.ToList());
        //    return View(db.table_house_senior_details
          //             .Include(b => b.table_demographic)
            //             .ToList(););
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