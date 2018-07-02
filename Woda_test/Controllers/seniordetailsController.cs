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
    public class seniordetailsController : Controller
    {
        private woda_testEntities db = new woda_testEntities();

        // GET: seniordetails
        public ActionResult Index()
        {
            return View(db.table_house_senior_details.ToList());
        }

        // GET: seniordetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_house_senior_details table_house_senior_details = db.table_house_senior_details.Find(id);
            if (table_house_senior_details == null)
            {
                return HttpNotFound();
            }
            return View(table_house_senior_details);
        }

        // GET: seniordetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: seniordetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "senior_id,Home_no,Education,Occupation,Contact_no,DOB,BirthPlace,CitizenShip_no,CitizenshipIssue_district,Name")] table_house_senior_details table_house_senior_details)
        {
            if (ModelState.IsValid)
            {
                db.table_house_senior_details.Add(table_house_senior_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_house_senior_details);
        }

        // GET: seniordetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_house_senior_details table_house_senior_details = db.table_house_senior_details.Find(id);
            if (table_house_senior_details == null)
            {
                return HttpNotFound();
            }
            return View(table_house_senior_details);
        }

        // POST: seniordetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "senior_id,Home_no,Education,Occupation,Contact_no,DOB,BirthPlace,CitizenShip_no,CitizenshipIssue_district,Name")] table_house_senior_details table_house_senior_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_house_senior_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_house_senior_details);
        }

        // GET: seniordetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_house_senior_details table_house_senior_details = db.table_house_senior_details.Find(id);
            if (table_house_senior_details == null)
            {
                return HttpNotFound();
            }
            return View(table_house_senior_details);
        }

        // POST: seniordetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table_house_senior_details table_house_senior_details = db.table_house_senior_details.Find(id);
            db.table_house_senior_details.Remove(table_house_senior_details);
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
