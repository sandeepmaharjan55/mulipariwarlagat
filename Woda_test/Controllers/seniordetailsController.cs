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
        public ActionResult Index(string q, string order)
        {
            var name = from n in db.table_house_senior_details select n;
            if (q != null)
            {
                name = name.Where(n => n.Name.Contains(q));
            }
            switch (order)
            {
                case "name":
                    name = name.OrderBy(n => n.Name);
                    break;
                case "home":
                    name = name.OrderBy(n => n.Home_no);
                    break;
                default:
                    name = name.OrderBy(n => n.senior_id);
                    break;
            }
            return View(name.ToList());
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
            var result = db.pdffiles // this explicit query is here
                            .Where(stats => stats.senior_status == false)
                            .Take(1);
            //.Select(stats => new
            //             {
            //               File = stats.File

            //         });
            foreach (var item in result)
            {

                ViewBag.file = item.File;
            }

            return View();
        }

        // POST: seniordetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "senior_id,Home_no,Education,Occupation,Contact_no,DOB,BirthPlace,CitizenShip_no,CitizenshipIssue_district,citizenissue_date,Name")] table_house_senior_details table_house_senior_details)
        {
            if (ModelState.IsValid)
            {

                if (!db.table_house_senior_details.Any(u => u.Home_no == table_house_senior_details.Home_no))
                {
                    db.table_house_senior_details.Add(table_house_senior_details);
                db.SaveChanges();

                    var result = db.pdffiles // this explicit query is here
                               .Where(stats => stats.senior_status == false)
                               .Take(1);

                    foreach (var item in result)
                    {

                        ViewBag.file = item.File;
                        pdffile pdff = new pdffile();
                        using (var con = new woda_testEntities())
                        {
                            pdff = con.pdffiles.First(x => x.File == item.File);
                            pdff.senior_status = true;

                            con.pdffiles.Attach(pdff);
                            var entry = con.Entry(pdff);
                            entry.Property(e => e.senior_status).IsModified = true;
                            con.SaveChanges();
                        }
                    }
                    return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "This Home Number already added";

            }
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
        public ActionResult Edit([Bind(Include = "senior_id,Home_no,Education,Occupation,Contact_no,DOB,BirthPlace,CitizenShip_no,CitizenshipIssue_district,citizenissue_date,Name")] table_house_senior_details table_house_senior_details)
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
