using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAPIWithAppInsights.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleApiController : ControllerBase
    {
        [HttpGet("SuccessGet")]
        public ActionResult<string> SampleSuccessGet()
        {
            return Ok("SampleSuccessGetResult");
        }
        [HttpGet("ForbidGet")]
        public ActionResult<string> SampleFailGet()
        {
            return Forbid("SampleForbidGetResult");
        }
        [HttpGet("SampleBadRequestGet")]
        public ActionResult<string> SampleBadRequestGet()
        {
            throw new Exception();
        }
        [HttpGet("RedirectGet")]
        public ActionResult<string> SampleRedirectGet()
        {
            Random random = new Random();
            switch (random.Next(1, 3))
            {
                case 1:
                    return RedirectPermanent(Url.Action("SampleBadRequestGet"));
                case 2:
                    return RedirectPermanent(Url.Action("SuccessGet"));
                case 3:
                    return RedirectPermanent(Url.Action("ForbidGet"));
                default:
                    return NotFound();
            }
        }
        [HttpPut("SuccessPut")]
        public ActionResult SampleSuccessPut([FromBody] SampleInput input)
        {
            return Ok();
        }
        [HttpPut("FailPut")]
        public ActionResult SampleFailPut([FromBody] SampleInput input)
        {
            throw new Exception();
        }
        [HttpPost("SuccessPost")]
        public ActionResult SampleSuccessPost([FromBody] SampleInput input)
        {
            return Ok();
        }
        [HttpPost("FailPost")]
        public ActionResult SampleFailPost([FromBody] SampleInput input)
        {
            throw new Exception();
        }
        [HttpDelete("SuccessDelete")]
        public ActionResult SampleSuccessDelete([FromQuery] int id)
        {
            return Ok();
        }
        [HttpDelete("FailDelete")]
        public ActionResult SampleFailDelete([FromQuery]int id)
        {
            throw new Exception();
        }
    }

    public class SampleInput
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
