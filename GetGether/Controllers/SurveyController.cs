using Microsoft.AspNetCore.Mvc;
using GetGether.Models;
using GetGether.Data;
using Microsoft.EntityFrameworkCore;
using GetGether;
using GetGether.Repository.Interfaces;
using System.Reflection.Metadata;
using GetGether.Services;
using GetGether.Services.Interfaces;
using System.Xml.Linq;


namespace GetGether.Controllers
{

     [ApiController]
    [Route("[controller]")]
    public class SurveyController : ControllerBase
    {
       //private GlobalDbContext _context;

       // public SurveyController(GlobalDbContext context) 
       // {
       //     _context = context;

       // }

        private ITestService TestService { get; set; }
        private IBaseRepository<Survey> Surveys { get; set; }

        public SurveyController(ITestService testService, IBaseRepository<Survey> survey)
        {
            TestService = testService;
            Surveys = survey;
        }

        [HttpGet(Name = "GetSurvey")]
        public JsonResult Get()
        {
            List<Survey> surveys = Surveys.GetAll();

            var surveyContainer = new SurveyContainer
            {
                surveys = surveys
            };

            return new JsonResult(surveyContainer);
        }


        [HttpPost]
        public JsonResult Post()                                      //запрос создает новый объект survey через TestService , а именно его функцию Work 
        {
            TestService.Work();
            return new JsonResult("Work was successfully done");
        }







        [HttpPut]
        public JsonResult Put(Survey surv)
        {
            bool success = true;
            var surveys = Surveys.Get(surv.Id);
            try
            {
                if (surveys != null)
                {
                    surveys = Surveys.Update(surv);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult($"Update successful {surveys.Id}") : new JsonResult("Update was not successful");
        }




        
        



    }
}
