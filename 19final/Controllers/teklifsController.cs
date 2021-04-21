using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _19final.Models;

namespace _19final.Controllers
{
    public class teklifsController : Controller
    {
        private Entities db = new Entities();

        // GET: teklifs
        public ActionResult Index()
        {
            return View(db.teklifs.ToList());
        }

        // GET: teklifs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teklif teklif = db.teklifs.Find(id);
            if (teklif == null)
            {
                return HttpNotFound();
            }
            return View(teklif);
        }

        // GET: teklifs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: teklifs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,email,mesaj")] teklif teklif)
        {
            if (ModelState.IsValid)
            {
                db.teklifs.Add(teklif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teklif);
        }

        // GET: teklifs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teklif teklif = db.teklifs.Find(id);
            if (teklif == null)
            {
                return HttpNotFound();
            }
            return View(teklif);
        }

        // POST: teklifs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,email,mesaj")] teklif teklif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teklif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teklif);
        }

        // GET: teklifs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teklif teklif = db.teklifs.Find(id);
            if (teklif == null)
            {
                return HttpNotFound();
            }
            return View(teklif);
        }

        // POST: teklifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teklif teklif = db.teklifs.Find(id);
            db.teklifs.Remove(teklif);
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
