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
    public class pariwarbektibibarandController : Controller
    {
        private woda_testEntities db = new woda_testEntities();

        // GET: pariwarbektibibarand
        public ActionResult Index()
        {
            var pariwar_bekti_bibarand = db.pariwar_bekti_bibarand.Include(p => p.table_house_senior_details);
            return View(pariwar_bekti_bibarand.ToList());
        }

        // GET: pariwarbektibibarand/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pariwar_bekti_bibarand pariwar_bekti_bibarand = db.pariwar_bekti_bibarand.Find(id);
            if (pariwar_bekti_bibarand == null)
            {
                return HttpNotFound();
            }
            return View(pariwar_bekti_bibarand);
        }

        // GET: pariwarbektibibarand/Create
        public ActionResult Create()
        {
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no");
            return View();
        }

        // POST: pariwarbektibibarand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PB_ID,senior_id")] pariwar_bekti_bibarand pariwar_bekti_bibarand)
        {
            if (ModelState.IsValid)
            {
                db.pariwar_bekti_bibarand.Add(pariwar_bekti_bibarand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no", pariwar_bekti_bibarand.senior_id);
            return View(pariwar_bekti_bibarand);
        }

        // GET: pariwarbektibibarand/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pariwar_bekti_bibarand pariwar_bekti_bibarand = db.pariwar_bekti_bibarand.Find(id);
            if (pariwar_bekti_bibarand == null)
            {
                return HttpNotFound();
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no", pariwar_bekti_bibarand.senior_id);
            return View(pariwar_bekti_bibarand);
        }

        // POST: pariwarbektibibarand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PB_ID,senior_id")] pariwar_bekti_bibarand pariwar_bekti_bibarand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pariwar_bekti_bibarand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no", pariwar_bekti_bibarand.senior_id);
            return View(pariwar_bekti_bibarand);
        }

        // GET: pariwarbektibibarand/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pariwar_bekti_bibarand pariwar_bekti_bibarand = db.pariwar_bekti_bibarand.Find(id);
            if (pariwar_bekti_bibarand == null)
            {
                return HttpNotFound();
            }
            return View(pariwar_bekti_bibarand);
        }

        // POST: pariwarbektibibarand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pariwar_bekti_bibarand pariwar_bekti_bibarand = db.pariwar_bekti_bibarand.Find(id);
            db.pariwar_bekti_bibarand.Remove(pariwar_bekti_bibarand);
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
