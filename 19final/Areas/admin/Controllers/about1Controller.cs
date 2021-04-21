using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _19final.Models;

namespace _19final.Areas.admin.Controllers
{
    public class about1Controller : Controller
    {
        private Entities db = new Entities();

        // GET: admin/about1
        public ActionResult Index()
        {
            return View(db.about1.ToList());
        }

        // GET: admin/about1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            about1 about1 = db.about1.Find(id);
            if (about1 == null)
            {
                return HttpNotFound();
            }
            return View(about1);
        }

        // GET: admin/about1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/about1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,etrafli")] about1 about1)
        {
            if (ModelState.IsValid)
            {
                db.about1.Add(about1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about1);
        }

        // GET: admin/about1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            about1 about1 = db.about1.Find(id);
            if (about1 == null)
            {
                return HttpNotFound();
            }
            return View(about1);
        }

        // POST: admin/about1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,etrafli")] about1 about1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(about1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about1);
        }

        // GET: admin/about1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            about1 about1 = db.about1.Find(id);
            if (about1 == null)
            {
                return HttpNotFound();
            }
            return View(about1);
        }

        // POST: admin/about1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            about1 about1 = db.about1.Find(id);
            db.about1.Remove(about1);
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
