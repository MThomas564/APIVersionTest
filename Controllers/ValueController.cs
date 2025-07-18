using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APIVersionTest.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/{action}")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class ValueController : ControllerBase
    {
        // GET api/v1/value/getv1
        [HttpGet]
        [MapToApiVersion("1")]
        public IActionResult GetV1()
        {
            return Ok("Value from API Version 1");
        }

        // GET api/v2/value/getv2
        [HttpGet]
        [MapToApiVersion("2")]
        public IActionResult GetV2()
        {
            return Ok("Value from API Version 2");
        }

        // GET api/v2/value/get
        [HttpGet]
        [MapToApiVersion("2")]
        public IActionResult Get()
        {
            return Ok("Value from API Version 2 (default)");
        }
    }
}