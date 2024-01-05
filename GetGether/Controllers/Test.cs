using GetGether.Data;
using GetGether.Models;
using GetGether.Services;
using GetGether.Services.Implimentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GetGether.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TestController : ControllerBase
    {

        private readonly GlobalDBContext _dbContext;
        private readonly IAuthService _authService;
        public TestController(GlobalDBContext dbContext, IAuthService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }



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

        [HttpPost("AddTestUsers")]
        public async Task<IActionResult> AddTestUsers()
        {
            var addTestDatas = new AddTestDatas(_dbContext, _authService);
            var result = addTestDatas.AddDataToDataBase();

            if (result)
            {
                return Ok($"Successful creation!");
            }
            else
            {
                return BadRequest($"Unsuccessful!");
            }
        }

        
    }
}
