using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using CRUDWebApiWithSwagger.Models;
using Microsoft.AspNetCore.Mvc;
using WebApiWithSwagger.Models;

namespace WebApiWithSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly CrudSampleContext _crudSampleContext;
        public ValuesController(CrudSampleContext crudSampleContext)
        {
            this._crudSampleContext = crudSampleContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<ValueSamples>> Get()
        {
            var itemLst = _crudSampleContext.ValueSamples.ToList();
            return new List<ValueSamples>(itemLst);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var itemToReturn = _crudSampleContext.ValueSamples.Where(x => x.Id == id).FirstOrDefault();
            return itemToReturn.Name;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ValueSamples createSample)
        {
            _crudSampleContext.ValueSamples.Add(createSample);
            _crudSampleContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] ValueSamples updateSample)
        {
            _crudSampleContext.ValueSamples.Update(updateSample);
            _crudSampleContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var itemToDelete = _crudSampleContext.ValueSamples.Where(x => x.Id == id).FirstOrDefault();
            _crudSampleContext.ValueSamples.Remove(itemToDelete);
            _crudSampleContext.SaveChanges();
        }
    }
}