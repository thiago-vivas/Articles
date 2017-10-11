using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace AzureRedisCache.Controllers
{
    public class HomeController : Controller
    {
        private IDistributedCache _cache;

        public HomeController(IDistributedCache cache)
        {
            this._cache = cache;
        }
        public IActionResult Index()
        {
           string test = _cache.GetString("Test") ?? "";
            if (string.IsNullOrEmpty( test))
            {
                _cache.SetString("Test", "Tested");
                test = JsonConvert.DeserializeObject<string>(_cache.GetString("Test") ?? "");
            }
            ViewData["Test"] = test;
            return View();
        }

    }
}
