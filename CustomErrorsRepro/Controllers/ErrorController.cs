using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomErrorsRepro.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Http500()
        {
            return View();
        }
    }
}