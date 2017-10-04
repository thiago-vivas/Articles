using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebVerbs.Controllers
{
    [Produces("application/json")]
    [Route("api/Sample")]
    public class SampleController : Controller
    {
        public static Dictionary<int, string> data;
        public SampleController()
        {
            this.LoadSampleObject();
        }
        public void LoadSampleObject()
        {
            data = new Dictionary<int, string>();
            data.Add(0, "object 0");
            data.Add(1, "object 1");
            data.Add(2, "object 2");
            data.Add(3, "object 3");
            data.Add(4, "object 4");
            data.Add(5, "object 5");
            data.Add(6, "object 6");
        }

        [HttpGet("{id}")]
        public KeyValuePair<int, string> Get(int id)
        {
            return data.FirstOrDefault(x=> x.Key == id);
        }

        [HttpGet]
        public Dictionary<int, string> Get()
        {
            return data;
        }


        // POST api/values
        [HttpPost("{id}/{name}")]
        public void Post(int id, string name)
        {
            data.Add(id, name);
            RedirectToAction("Get");
        }

        // PUT api/values/5
        [HttpPut("{id}/{name}")]
        public void Put(int id, string name)
        {
            data[id] = name;
            RedirectToAction("Get");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            data.Remove(id);
            RedirectToAction("Get");
        }

    }
}