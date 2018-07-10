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
    public class swostasewaController : Controller
    {
        private woda_testEntities db = new woda_testEntities();

        // GET: swostasewa
        public ActionResult Index()
        {
            var swosta_sewa = db.swosta_sewa.Include(s => s.table_house_senior_details);
            return View(swosta_sewa.ToList());
        }

        // GET: swostasewa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            swosta_sewa swosta_sewa = db.swosta_sewa.Find(id);
            if (swosta_sewa == null)
            {
                return HttpNotFound();
            }
            return View(swosta_sewa);
        }

        // GET: swostasewa/Create
        public ActionResult Create()
        {
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no");
            return View();
        }

        // POST: swostasewa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sewaID,khop,mahila_posand,upachar,senior_id")] swosta_sewa swosta_sewa)
        {
            if (ModelState.IsValid)
            {
                db.swosta_sewa.Add(swosta_sewa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no", swosta_sewa.senior_id);
            return View(swosta_sewa);
        }

        // GET: swostasewa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            swosta_sewa swosta_sewa = db.swosta_sewa.Find(id);
            if (swosta_sewa == null)
            {
                return HttpNotFound();
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Education", swosta_sewa.senior_id);
            return View(swosta_sewa);
        }

        // POST: swostasewa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sewaID,khop,mahila_posand,upachar,senior_id")] swosta_sewa swosta_sewa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(swosta_sewa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Education", swosta_sewa.senior_id);
            return View(swosta_sewa);
        }

        // GET: swostasewa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            swosta_sewa swosta_sewa = db.swosta_sewa.Find(id);
            if (swosta_sewa == null)
            {
                return HttpNotFound();
            }
            return View(swosta_sewa);
        }

        // POST: swostasewa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            swosta_sewa swosta_sewa = db.swosta_sewa.Find(id);
            db.swosta_sewa.Remove(swosta_sewa);
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
