using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19final.Models;

namespace _19final.Areas.admin.Controllers
{
    public class adminaccountController : Controller
    {
        Entities db = new Entities();
        // GET: admin/adminaccount
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(adminlogin adm)
        {
            adminlogin admset = db.adminlogins.FirstOrDefault(x=>x.email==adm.email);
            if(admset != null)
            {
                if (admset.password == adm.password)
                {
                    Session["add1"] = admset;
                    return RedirectToAction("Index", "home");
                }
            }
            return View();
        }
    }
}