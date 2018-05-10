using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreDataAnnotation.Models;

namespace NetCoreDataAnnotation.Controllers
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
            return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
        }

        public IActionResult TripManagerSample()
        {
            return View();
        }

        public IActionResult HotelSample()
        {
            var lstHotel = new List<Hotel>();
            lstHotel.Add( new Hotel { Id = 1, Name = null } );
            lstHotel.Add( new Hotel { Id = 2, Name = "Best one ever" } );
            return View( lstHotel );
        }

        public IActionResult PersonSample()
        {
            return View();
        }
    }
}