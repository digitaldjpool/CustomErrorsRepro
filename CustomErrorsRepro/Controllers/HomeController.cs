using CustomErrorsRepro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomErrorsRepro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            throw new Exception("CustomErrorsRepro exception thrown!");

            return View();
        }

        public ActionResult MemoryLog()
        {
            var cache = new System.Web.Caching.Cache();
            return View(cache.Get("log") as List<LogMessage>);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}