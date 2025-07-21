using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APIVersionTest.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(ApiVersions.v2)]
    public class TestController : ControllerBase
    {
        [ProducesResponseType(typeof(string), 200)]
        [Produces("application/json")]
        [Tags("Coffee", "Version2")]
        [ApiExplorerSettings(GroupName = "v2")]
        [EndpointDescription("Gets a message indicating the user's preference for coffee, specific to API Version 2.")]
        [HttpGet]
        [MapToApiVersion(ApiVersions.v2)]
        public IActionResult Coffee()
        {
            return Ok("I'm a coffee lover from API Version 2");
        }
    }
}