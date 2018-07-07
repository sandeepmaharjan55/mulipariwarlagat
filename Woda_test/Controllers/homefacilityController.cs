using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Woda_test.Models;

namespace Woda_test.Controllers
{
    public class homefacilityController : Controller
    {
        private woda_testEntities db = new woda_testEntities();

        // GET: homefacility
        public ActionResult Index(string q, string order)
        {
            var name = from n in db.table_home_facility select n;
            if (q != null)
            {
                name = name.Where(n => n.House_type.Contains(q));
            }
            switch (order)
            {
                case "entertain":
                    name = name.OrderBy(n => n.entertainment);
                    break;
               
                default:
                    name = name.OrderBy(n => n.senior_id);
                    break;
            }
            return View(name.ToList());
        }

        // GET: homefacility/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_home_facility table_home_facility = db.table_home_facility.Find(id);
            if (table_home_facility == null)
            {
                return HttpNotFound();
            }
            return View(table_home_facility);
        }

        // GET: homefacility/Create
        public ActionResult Create()
        {
            var result = db.pdffiles // this explicit query is here
                            .Where(stats => stats.status == false)
                            .Take(1);
            //.Select(stats => new
            //             {
            //               File = stats.File

            //         });
            foreach (var item in result)
            {

                ViewBag.file = item.File;
            }

            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no");
            return View();
        }

        // POST: homefacility/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "F_id,House_type,House_area,House_total_area,roof_type,on_rent,cooking_type,entertainment,annual_income,drinking_water_TYPE,irrigation_type,ownership_type,storey,electricity,senior_id")] table_home_facility table_home_facility)
        {
            if (ModelState.IsValid)
            {
                if (!db.table_home_facility.Any(u => u.senior_id == table_home_facility.senior_id))
                {
                    db.table_home_facility.Add(table_home_facility);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "This Home Number already added";

                }
            }

            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no", table_home_facility.senior_id);
            return View(table_home_facility);
        }

        // GET: homefacility/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_home_facility table_home_facility = db.table_home_facility.Find(id);
            if (table_home_facility == null)
            {
                return HttpNotFound();
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no", table_home_facility.senior_id);
            return View(table_home_facility);
        }

        // POST: homefacility/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "F_id,House_type,House_area,House_total_area,roof_type,on_rent,cooking_type,entertainment,annual_income,drinking_water_TYPE,irrigation_type,ownership_type,storey,electricity,senior_id")] table_home_facility table_home_facility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_home_facility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no", table_home_facility.senior_id);
            return View(table_home_facility);
        }

        // GET: homefacility/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_home_facility table_home_facility = db.table_home_facility.Find(id);
            if (table_home_facility == null)
            {
                return HttpNotFound();
            }
            return View(table_home_facility);
        }

        // POST: homefacility/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table_home_facility table_home_facility = db.table_home_facility.Find(id);
            db.table_home_facility.Remove(table_home_facility);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
