using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace trackingapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Apiconnect : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // Process the request and return a response
            return Ok("Response from API B");
        }
    }

}

