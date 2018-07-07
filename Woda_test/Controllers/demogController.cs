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
    public class demogController : Controller
    {
        private woda_testEntities db = new woda_testEntities();

        // GET: demog
        public ActionResult Index(string q, string order)
        {
            var name = from n in db.table_demographic select n;
            if (q != null)
            {
                name = name.Where(n => n.caste.Contains(q));
            }
            switch (order)
            {
                case "caste":
                    name = name.OrderBy(n => n.caste);
                    break;
                case "religion":
                    name = name.OrderBy(n => n.religion);
                    break;

                default:
                    name = name.OrderBy(n => n.senior_id);
                    break;
            }
            return View(name.ToList());
            // var table_demographic = db.table_demographic.Include(t => t.table_house_senior_details);
            //  return View(table_demographic.ToList());
        }

        // GET: demog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_demographic table_demographic = db.table_demographic.Find(id);
            if (table_demographic == null)
            {
                return HttpNotFound();
            }
            return View(table_demographic);
        }

        // GET: demog/Create
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

        // POST: demog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "D_id,Total_person,Male_count,Female_count,caste,religion,senior_id")] table_demographic table_demographic)
        {
            if (ModelState.IsValid)
            {
                if (!db.table_demographic.Any(u => u.senior_id == table_demographic.senior_id))
                {
                    db.table_demographic.Add(table_demographic);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "This Home Number already added";

                }
            }

            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no", table_demographic.senior_id);
            return View(table_demographic);
        }

        // GET: demog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_demographic table_demographic = db.table_demographic.Find(id);
            if (table_demographic == null)
            {
                return HttpNotFound();
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no", table_demographic.senior_id);
            return View(table_demographic);
        }

        // POST: demog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "D_id,Total_person,Male_count,Female_count,caste,religion,senior_id")] table_demographic table_demographic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_demographic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.senior_id = new SelectList(db.table_house_senior_details, "senior_id", "Home_no", table_demographic.senior_id);
            return View(table_demographic);
        }

        // GET: demog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_demographic table_demographic = db.table_demographic.Find(id);
            if (table_demographic == null)
            {
                return HttpNotFound();
            }
            return View(table_demographic);
        }

        // POST: demog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table_demographic table_demographic = db.table_demographic.Find(id);
            db.table_demographic.Remove(table_demographic);
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
