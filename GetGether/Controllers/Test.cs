using GetGether.Models;
using GetGether.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GetGether.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TestController : ControllerBase
    {


        [HttpPost("AuthTest")]
        [Authorize]
        public async Task<IActionResult> AuthTest()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId != null)
            {
                // Идентификатор пользователя доступен в переменной userId
                return Ok($"User Id: {userId} ");
            }
            else
            {
                // Пользователь не аутентифицирован
                return Unauthorized();
            }
        }


    }
}
