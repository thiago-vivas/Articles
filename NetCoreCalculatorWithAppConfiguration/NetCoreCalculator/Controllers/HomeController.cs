using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NetCoreCalculator.Business;
using NetCoreCalculator.Models;

namespace NetCoreCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Secret = this.configuration["samplekeyonappconfiguration"];
            return View();
        }

        [HttpPost]
        public IActionResult Index( Operation model )
        {
            if ( model.OperationType == OperationType.Addition )
                model.Result = model.NumberA + model.NumberB;
            return View( model );
        }

        [HttpPost]
        public IActionResult CompoundInterest( CompoundInterestModel model )
        {
            model.Result = Calculation.CalculateCompoundInterest( model );
            return View( model );
        }

        [HttpGet]
        public IActionResult CompoundInterest()
        {
            return View();
        }
    }
}