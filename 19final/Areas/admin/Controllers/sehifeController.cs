using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using _19final.Models;

namespace _19final.Areas.admin.Controllers
{
    public class sehifeController : Controller
    {
         Entities db = new Entities();

        // GET: admin/sehife
        public ActionResult Index()
        {
           

            return View(db.homes.ToList());
        }

        // GET: admin/sehife/Details/5
        public ActionResult Details(int? id)
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

        // GET: admin/sehife/Create
        public ActionResult Create()
        {

         

            if (db.homes.Count() >= 1000)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: admin/sehife/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(home home, HttpPostedFileBase photourl)
        {

          

            if (ModelState.IsValid)
            {

                WebImage img = new WebImage(photourl.InputStream);
                FileInfo file = new FileInfo(photourl.FileName);
                string imgname = Guid.NewGuid() + file.Extension;
                img.Save("~/upload/" + imgname);
                home.photourl = "/upload/" + imgname;
                db.homes.Add(home);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: admin/sehife/Edit/5
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

        // POST: admin/sehife/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(int? id, string basliq1, string etrafli1, HttpPostedFileBase photourl)
        {




            home sa2 = db.homes.FirstOrDefault(x => x.ID == id);

            if (photourl != null)
            {
                WebImage img = new WebImage(photourl.InputStream);
                FileInfo file = new FileInfo(photourl.FileName);
                string imgname = Guid.NewGuid() + file.Extension;
                img.Save("~/upload/" + imgname);
                sa2.photourl = "/upload/" + imgname;
            }
            sa2.basliq = basliq1;
            sa2.etrafli = etrafli1;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: admin/sehife/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: admin/sehife/Delete/5
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
