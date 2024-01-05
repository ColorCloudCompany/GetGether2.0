using GetGether.Repository.Interfaces;
using GetGether.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GetGether.Models.ForControllers.Containers;

namespace GetGether.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BasePageController : ControllerBase
    {

        private IBaseRepository<Event> Events { get; set; }  //Хранилище списка событий

        public BasePageController(IBaseRepository<Event> Events) 
        {
            this.Events = Events;
        }


        [HttpGet("GetBasePage")]
        public async Task<IActionResult> AuthTest()
        {

            List<Event> EventList = Events.GetAll();

            var eventContainer = new EventContainer
            {
                Events = EventList
            };

            
            return new JsonResult(eventContainer);

        }

               

    


        [HttpPost("Participate")]
        [Authorize]
        public async Task<IActionResult> AuthTest1()
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
