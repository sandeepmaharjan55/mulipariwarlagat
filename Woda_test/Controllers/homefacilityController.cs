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
        private wodaEntities db = new wodaEntities();

        // GET: homefacility
        public ActionResult Index()
        {
            var table_home_facilities = db.table_home_facilities.Include(t => t.table_address).Include(t => t.table_demographic).Include(t => t.table_house_senior_detail);
            return View(table_home_facilities.ToList());
        }

        // GET: homefacility/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_home_facilities table_home_facilities = db.table_home_facilities.Find(id);
            if (table_home_facilities == null)
            {
                return HttpNotFound();
            }
            return View(table_home_facilities);
        }

        // GET: homefacility/Create
        public ActionResult Create()
        {
            ViewBag.Home_no = new SelectList(db.table_address, "id", "Sabik_gabisa");
            ViewBag.Home_no = new SelectList(db.table_demographic, "id", "caste");
            ViewBag.Home_no = new SelectList(db.table_house_senior_detail, "id", "Name");
            return View();
        }

        // POST: homefacility/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Home_no,House_type,House_area,House_total_area,roof_type,on_rent,cooking_type,Entertainment,Annual_income,Drinking_water_type,Irrigation_type,road_type,ownership_type,storey,electricity")] table_home_facilities table_home_facilities)
        {
            if (ModelState.IsValid)
            {
                db.table_home_facilities.Add(table_home_facilities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Home_no = new SelectList(db.table_address, "id", "Sabik_gabisa", table_home_facilities.Home_no);
            ViewBag.Home_no = new SelectList(db.table_demographic, "id", "caste", table_home_facilities.Home_no);
            ViewBag.Home_no = new SelectList(db.table_house_senior_detail, "id", "Name", table_home_facilities.Home_no);
            return View(table_home_facilities);
        }

        // GET: homefacility/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_home_facilities table_home_facilities = db.table_home_facilities.Find(id);
            if (table_home_facilities == null)
            {
                return HttpNotFound();
            }
            ViewBag.Home_no = new SelectList(db.table_address, "id", "Sabik_gabisa", table_home_facilities.Home_no);
            ViewBag.Home_no = new SelectList(db.table_demographic, "id", "caste", table_home_facilities.Home_no);
            ViewBag.Home_no = new SelectList(db.table_house_senior_detail, "id", "Name", table_home_facilities.Home_no);
            return View(table_home_facilities);
        }

        // POST: homefacility/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Home_no,House_type,House_area,House_total_area,roof_type,on_rent,cooking_type,Entertainment,Annual_income,Drinking_water_type,Irrigation_type,road_type,ownership_type,storey,electricity")] table_home_facilities table_home_facilities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_home_facilities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Home_no = new SelectList(db.table_address, "id", "Sabik_gabisa", table_home_facilities.Home_no);
            ViewBag.Home_no = new SelectList(db.table_demographic, "id", "caste", table_home_facilities.Home_no);
            ViewBag.Home_no = new SelectList(db.table_house_senior_detail, "id", "Name", table_home_facilities.Home_no);
            return View(table_home_facilities);
        }

        // GET: homefacility/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_home_facilities table_home_facilities = db.table_home_facilities.Find(id);
            if (table_home_facilities == null)
            {
                return HttpNotFound();
            }
            return View(table_home_facilities);
        }

        // POST: homefacility/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table_home_facilities table_home_facilities = db.table_home_facilities.Find(id);
            db.table_home_facilities.Remove(table_home_facilities);
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
