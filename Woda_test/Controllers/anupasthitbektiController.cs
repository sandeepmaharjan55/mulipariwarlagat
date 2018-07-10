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
    public class anupasthitbektiController : Controller
    {
        private woda_testEntities db = new woda_testEntities();

        // GET: anupasthitbekti
        public ActionResult Index()
        {
            var anupasthit_bekti = db.anupasthit_bekti.Include(a => a.table_house_senior_details).Include(a => a.anupasthit_bekti_many);
            return View(anupasthit_bekti.ToList());
        }

        // GET: anupasthitbekti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anupasthit_bekti anupasthit_bekti = db.anupasthit_bekti.Find(id);
            if (anupasthit_bekti == null)
            {
                return HttpNotFound();
            }
            return View(anupasthit_bekti);
        }

        // GET: anupasthitbekti/Create
        public ActionResult Create()
        {
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no");
            return View();
        }

        // POST: anupasthitbekti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AB_ID,senior_id")] anupasthit_bekti anupasthit_bekti)
        {
            if (ModelState.IsValid)
            {
                db.anupasthit_bekti.Add(anupasthit_bekti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no", anupasthit_bekti.senior_id);
            return View(anupasthit_bekti);
        }

        // GET: anupasthitbekti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anupasthit_bekti anupasthit_bekti = db.anupasthit_bekti.Find(id);
            if (anupasthit_bekti == null)
            {
                return HttpNotFound();
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no", anupasthit_bekti.senior_id);
            return View(anupasthit_bekti);
        }

        // POST: anupasthitbekti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AB_ID,senior_id")] anupasthit_bekti anupasthit_bekti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anupasthit_bekti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Education", anupasthit_bekti.senior_id);
            return View(anupasthit_bekti);
        }

        // GET: anupasthitbekti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anupasthit_bekti anupasthit_bekti = db.anupasthit_bekti.Find(id);
            if (anupasthit_bekti == null)
            {
                return HttpNotFound();
            }
            return View(anupasthit_bekti);
        }

        // POST: anupasthitbekti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            anupasthit_bekti anupasthit_bekti = db.anupasthit_bekti.Find(id);
            db.anupasthit_bekti.Remove(anupasthit_bekti);
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
