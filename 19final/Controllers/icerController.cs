using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19final.Models;

namespace _19final.Controllers
{
    public class icerController : Controller
    {
        Entities db = new Entities();

        // GET: icer
        public ActionResult Index()
        {
            return View(db.homes.ToList());
        }
    }
}