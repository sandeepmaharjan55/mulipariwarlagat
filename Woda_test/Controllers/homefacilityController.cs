﻿using System;
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
        public ActionResult Index()
        {
            var table_home_facility = db.table_home_facility.Include(t => t.table_house_senior_details);
            return View(table_home_facility.ToList());
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
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Education");
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
                db.table_home_facility.Add(table_home_facility);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Education", table_home_facility.senior_id);
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
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Education", table_home_facility.senior_id);
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
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Education", table_home_facility.senior_id);
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
