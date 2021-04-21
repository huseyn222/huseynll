using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19final.Models;

namespace _19final.Controllers
{
    public class haqqindaController : Controller
    {
        Entities db = new Entities();

        // GET: haqqinda
        public ActionResult Index()
        {
            return View(db.about1.First());
        }

        public ActionResult haqqinda()
        {
            return View();
        }
    }
}