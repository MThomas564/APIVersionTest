using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APIVersionTest.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class ValueController : ControllerBase
    {
        // GET api/v1/value/getv1
        [HttpGet("getv1")]
        [MapToApiVersion("1")]
        public IActionResult GetV1()
        {
            return Ok("Value from API Version 1");
        }

        // GET api/v2/value/getv2
        [HttpGet("getv2")]
        [MapToApiVersion("2")]
        public IActionResult GetV2()
        {
            return Ok("Value from API Version 2");
        }

        // GET api/v2/value/get
        [HttpGet("get")]
        [MapToApiVersion("2")]
        public IActionResult Get()
        {
            return Ok("Value from API Version 2 (default)");
        }

        [HttpGet("coffeevalue")]
        [MapToApiVersion("2")]
        public IActionResult CoffeeValue()
        {
            return Ok("I'm a coffee lover from API Version 2");
        }
    }
}