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
    public class apangataController : Controller
    {
        private woda_testEntities db = new woda_testEntities();

        // GET: apangata
        public ActionResult Index()
        {
            var apangatas = db.apangatas.Include(a => a.table_house_senior_details);
            return View(apangatas.ToList());
        }

        // GET: apangata/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            apangata apangata = db.apangatas.Find(id);
            if (apangata == null)
            {
                return HttpNotFound();
            }
            return View(apangata);
        }

        // GET: apangata/Create
        public ActionResult Create()
        {
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no");
            return View();
        }

        // POST: apangata/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "apangaID,apangata1,apanga_type,senior_id")] apangata apangata)
        {
            if (ModelState.IsValid)
            {
                db.apangatas.Add(apangata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no", apangata.senior_id);
            return View(apangata);
        }

        // GET: apangata/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            apangata apangata = db.apangatas.Find(id);
            if (apangata == null)
            {
                return HttpNotFound();
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Education", apangata.senior_id);
            return View(apangata);
        }

        // POST: apangata/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "apangaID,apangata1,apanga_type,senior_id")] apangata apangata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apangata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Education", apangata.senior_id);
            return View(apangata);
        }

        // GET: apangata/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            apangata apangata = db.apangatas.Find(id);
            if (apangata == null)
            {
                return HttpNotFound();
            }
            return View(apangata);
        }

        // POST: apangata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            apangata apangata = db.apangatas.Find(id);
            db.apangatas.Remove(apangata);
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
