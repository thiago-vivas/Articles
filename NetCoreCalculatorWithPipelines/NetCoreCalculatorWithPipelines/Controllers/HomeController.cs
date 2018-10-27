using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreCalculator.Models;

namespace NetCoreCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index( Operation model )
        {
            if ( model.OperationType == OperationType.Addition )
                model.Result = model.NumberA + model.NumberB;
            return View( model );
        }
    }
}