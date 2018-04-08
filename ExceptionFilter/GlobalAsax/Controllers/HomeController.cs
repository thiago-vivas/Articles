using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalAsax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            throw new Exception();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application thrown an error.";

            return View();
        }

        public ActionResult Contact()
        {
            throw new Exception();
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}