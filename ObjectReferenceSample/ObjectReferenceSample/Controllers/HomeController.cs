using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ObjectReferenceSample.Controllers
{

    public class HomeController : Controller
    {
        SampleObj sampleObj;
        SampleChildObj sampleChild;
        List<string> lstSample;
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
            sampleChild.Item2 = "error";
            return View();
        }

        public IActionResult ConditionStatement()
        {
            if (true == false)
            {
                sampleChild = new SampleChildObj();
                sampleChild.Item2 = "";
            }
            else
                sampleChild.Item2 = "error";

            return View();
        }
        public IActionResult ObjectInsideObject()
        {
            sampleObj = new SampleObj();
            sampleObj.ChildObj.Item2 = "error";
            return View();
        }
        public IActionResult AddInNullList()
        {
            lstSample.Add("error");
            return View();
        }
    }
    public class SampleObj
    {

        public string Item1 { get; set; }
        public SampleChildObj ChildObj { get; set; }
    }
    public class SampleChildObj 
    {
        public string Item2 { get; set; }
    }
}
