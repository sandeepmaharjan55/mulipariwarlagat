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
    public class anupasthitbektimanyController : Controller
    {
        private woda_testEntities db = new woda_testEntities();

        // GET: anupasthitbektimany
        public ActionResult Index()
        {
            
            var anupasthit_bekti_many = db.anupasthit_bekti_many.Include(a => a.anupasthit_bekti);
            return View(anupasthit_bekti_many.ToList());
        }

        // GET: anupasthitbektimany/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anupasthit_bekti_many anupasthit_bekti_many = db.anupasthit_bekti_many.Find(id);
            if (anupasthit_bekti_many == null)
            {
                return HttpNotFound();
            }
            return View(anupasthit_bekti_many);
        }

        // GET: anupasthitbektimany/Create
        public ActionResult Create()
        {
            ViewBag.AB_ID = new SelectList(db.anupasthit_bekti, "AB_ID", "senior_id");
            return View();
        }

        // POST: anupasthitbektimany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ABM_ID,Name,Gender,Total,went_place,gone_reason,AB_ID")] anupasthit_bekti_many anupasthit_bekti_many)
        {
            if (ModelState.IsValid)
            {
                db.anupasthit_bekti_many.Add(anupasthit_bekti_many);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AB_ID = new SelectList(db.anupasthit_bekti, "AB_ID", "senior_id", anupasthit_bekti_many.AB_ID);
            return View(anupasthit_bekti_many);
        }

        // GET: anupasthitbektimany/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anupasthit_bekti_many anupasthit_bekti_many = db.anupasthit_bekti_many.Find(id);
            if (anupasthit_bekti_many == null)
            {
                return HttpNotFound();
            }
            ViewBag.AB_ID = new SelectList(db.anupasthit_bekti, "AB_ID", "senior_id", anupasthit_bekti_many.AB_ID);
            return View(anupasthit_bekti_many);
        }

        // POST: anupasthitbektimany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ABM_ID,Name,Gender,Total,went_place,gone_reason,AB_ID")] anupasthit_bekti_many anupasthit_bekti_many)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anupasthit_bekti_many).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AB_ID = new SelectList(db.anupasthit_bekti, "AB_ID", "senior_id", anupasthit_bekti_many.AB_ID);
            return View(anupasthit_bekti_many);
        }

        // GET: anupasthitbektimany/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anupasthit_bekti_many anupasthit_bekti_many = db.anupasthit_bekti_many.Find(id);
            if (anupasthit_bekti_many == null)
            {
                return HttpNotFound();
            }
            return View(anupasthit_bekti_many);
        }

        // POST: anupasthitbektimany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            anupasthit_bekti_many anupasthit_bekti_many = db.anupasthit_bekti_many.Find(id);
            db.anupasthit_bekti_many.Remove(anupasthit_bekti_many);
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
