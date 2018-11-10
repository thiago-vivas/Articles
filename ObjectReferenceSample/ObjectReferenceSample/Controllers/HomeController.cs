using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ObjectReferenceSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult NewObject()
        {
            return View();
        }

        public IActionResult ConditionStatement()
        {
            return View();
        }
        public IActionResult ObjectInsideObject()
        {
            return View();
        }
        public IActionResult BoxedValue()
        {
            return View();
        }
        public IActionResult AddInNullList()
        {
            return View();
        }
    }
}
