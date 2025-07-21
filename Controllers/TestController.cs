using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APIVersionTest.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2")]
    public class TestController : ControllerBase
    {
        // GET api/v1/value/getv1
        [HttpGet]
        [MapToApiVersion("2")]
        public IActionResult Coffee()
        {
            return Ok("I'm a coffee lover from API Version 2");
        }
    }
}