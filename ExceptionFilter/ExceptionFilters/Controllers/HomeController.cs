using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionFilters.Controllers
{
    public class HomeController : Controller
    {
        [CustomExceptionFilter]
        public ActionResult Index()
        {
            throw new Exception();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application thrown an exception";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            throw new Exception();
            return View();
        }
    }
}