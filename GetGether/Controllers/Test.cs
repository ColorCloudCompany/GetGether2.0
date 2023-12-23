using GetGether.Models;
using GetGether.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetGether.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {


        [HttpPost("AuthTest")]
        public async Task<IActionResult> AuthTest()
        {
            return Content("Hello World!!!");
        }


    }
}
