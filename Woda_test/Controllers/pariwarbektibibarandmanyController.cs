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
    public class pariwarbektibibarandmanyController : Controller
    {
        private woda_testEntities db = new woda_testEntities();

        // GET: pariwarbektibibarandmany
        public ActionResult Index()
        {
            var pariwar_bekti_bibarand_many = db.pariwar_bekti_bibarand_many.Include(p => p.pariwar_bekti_bibarand);
            return View(pariwar_bekti_bibarand_many.ToList());
        }

        // GET: pariwarbektibibarandmany/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pariwar_bekti_bibarand_many pariwar_bekti_bibarand_many = db.pariwar_bekti_bibarand_many.Find(id);
            if (pariwar_bekti_bibarand_many == null)
            {
                return HttpNotFound();
            }
            return View(pariwar_bekti_bibarand_many);
        }

        // GET: pariwarbektibibarandmany/Create
        public ActionResult Create()
        {
            ViewBag.PB_ID = new SelectList(db.pariwar_bekti_bibarand, "PB_ID", "PB_ID");
            return View();
        }

        // POST: pariwarbektibibarandmany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PBM_ID,Name,nata,gender,birth_place,education,age,age_group,PB_ID")] pariwar_bekti_bibarand_many pariwar_bekti_bibarand_many)
        {
            if (ModelState.IsValid)
            {
                db.pariwar_bekti_bibarand_many.Add(pariwar_bekti_bibarand_many);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PB_ID = new SelectList(db.pariwar_bekti_bibarand, "PB_ID", "PB_ID", pariwar_bekti_bibarand_many.PB_ID);
            return View(pariwar_bekti_bibarand_many);
        }

        // GET: pariwarbektibibarandmany/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pariwar_bekti_bibarand_many pariwar_bekti_bibarand_many = db.pariwar_bekti_bibarand_many.Find(id);
            if (pariwar_bekti_bibarand_many == null)
            {
                return HttpNotFound();
            }
            ViewBag.PB_ID = new SelectList(db.pariwar_bekti_bibarand, "PB_ID", "PB_ID", pariwar_bekti_bibarand_many.PB_ID);
            return View(pariwar_bekti_bibarand_many);
        }

        // POST: pariwarbektibibarandmany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PBM_ID,Name,nata,gender,birth_place,education,age,age_group,PB_ID")] pariwar_bekti_bibarand_many pariwar_bekti_bibarand_many)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pariwar_bekti_bibarand_many).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PB_ID = new SelectList(db.pariwar_bekti_bibarand, "PB_ID", "PB_ID", pariwar_bekti_bibarand_many.PB_ID);
            return View(pariwar_bekti_bibarand_many);
        }

        // GET: pariwarbektibibarandmany/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pariwar_bekti_bibarand_many pariwar_bekti_bibarand_many = db.pariwar_bekti_bibarand_many.Find(id);
            if (pariwar_bekti_bibarand_many == null)
            {
                return HttpNotFound();
            }
            return View(pariwar_bekti_bibarand_many);
        }

        // POST: pariwarbektibibarandmany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pariwar_bekti_bibarand_many pariwar_bekti_bibarand_many = db.pariwar_bekti_bibarand_many.Find(id);
            db.pariwar_bekti_bibarand_many.Remove(pariwar_bekti_bibarand_many);
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
