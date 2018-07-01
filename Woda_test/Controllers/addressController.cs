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
    public class addressController : Controller
    {
        private woda_testEntities db = new woda_testEntities();

        // GET: address
        public ActionResult Index()
        {
            var table_address = db.table_address.Include(t => t.table_house_senior_details);
            return View(table_address.ToList());
        }

        // GET: address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_address table_address = db.table_address.Find(id);
            if (table_address == null)
            {
                return HttpNotFound();
            }
            return View(table_address);
        }

        // GET: address/Create
        public ActionResult Create()
        {
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Education");
            return View();
        }

        // POST: address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Add_id,Oda_no,Sabik_gabisa,Sabik_Oda,Tole,senior_id")] table_address table_address)
        {
            if (ModelState.IsValid)
            {
                db.table_address.Add(table_address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Education", table_address.senior_id);
            return View(table_address);
        }

        // GET: address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_address table_address = db.table_address.Find(id);
            if (table_address == null)
            {
                return HttpNotFound();
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Education", table_address.senior_id);
            return View(table_address);
        }

        // POST: address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Add_id,Oda_no,Sabik_gabisa,Sabik_Oda,Tole,senior_id")] table_address table_address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Education", table_address.senior_id);
            return View(table_address);
        }

        // GET: address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_address table_address = db.table_address.Find(id);
            if (table_address == null)
            {
                return HttpNotFound();
            }
            return View(table_address);
        }

        // POST: address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table_address table_address = db.table_address.Find(id);
            db.table_address.Remove(table_address);
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
