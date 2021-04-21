using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _19final.Models;

namespace _19final.Controllers
{
    public class detalController : Controller
    {
        private Entities db = new Entities();

        // GET: detal
        public async Task<ActionResult> Index()

        {
            return View(await db.homes.ToListAsync());

        }

        // GET: detal/Details/5


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            home home = await db.homes.FindAsync(id);
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }








        [HttpPost]

        public ActionResult Details(string photourl, string basliq, string etrafli)
        {

           
       
            return RedirectToAction("details");

        }

        // GET: detal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: detal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,photourl,basliq,etrafli")] home home)
        {
            if (ModelState.IsValid)
            {
                db.homes.Add(home);
               await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(home);
        }

        // GET: detal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            home home = db.homes.Find(id);
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }

        // POST: detal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,photourl,basliq,etrafli")] home home)
        {
            if (ModelState.IsValid)
            {
                db.Entry(home).State = EntityState.Modified;
               await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(home);
        }

        // GET: detal/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            home home = await db.homes.FindAsync(id);

            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }

        // POST: detal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            home home = db.homes.Find(id);
            db.homes.Remove(home);
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
