using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AzureRedisCache2.Models;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using AzureRedisCache2.Helpers;

namespace AzureRedisCache2.Controllers
{
    public class HomeController : Controller
    {
        private  IDistributedCache cache;
        public HomeController(IDistributedCache cache)
        {
            this.cache = cache;
        }
        public IActionResult Index()
        {
            return View(true);
        }

        public IActionResult SetSimpleComplexObject()
        {
            SampleObject sampleObject = new SampleObject
            {
                Country = "Brazil",
                Id = 7,
                Name = "Mané"
            };
            this.cache.SetHelper("test1", sampleObject);

            return RedirectToActionPermanent("Index");
        }

        public IActionResult SetListComplexObject()
        {
            List<SampleObject> lstSampleObject = new List<SampleObject>();
            lstSampleObject.Add(new SampleObject
            {
                Country = "Argentina",
                Id = 1,
                Name = "Maradona"
            });
            lstSampleObject.Add(new SampleObject
            {
                Country = "Portugal",
                Id = 2,
                Name = "Ronaldo"
            });
            lstSampleObject.Add(new SampleObject
            {
                Country = "Puskas",
                Id = 3,
                Name = "Hungary"
            });
            this.cache.SetHelper("test2", lstSampleObject);

            return RedirectToActionPermanent("Index");
        }

        public IActionResult GetSimpleComplexObject()
        {
            SampleObject sampleObject = new SampleObject();

            sampleObject = this.cache.GetHelper<SampleObject>("test1");
            return View(sampleObject);
        }

        public IActionResult GetListComplexObject()
        {
            List<SampleObject> lstSampleObject = new List<SampleObject>();

            lstSampleObject = this.cache.GetHelper<List<SampleObject>>("test2");

            return View(lstSampleObject);
        }
    }
}