using GetGether.Repository.Interfaces;
using GetGether.Services.Interfaces;
using System.Reflection.Metadata;
using GetGether.Data;
using GetGether.Models;
using GetGether.Repository.Implimentation;

namespace GetGether.Services.Implimentation
{
    public class TestService : ITestService
    {
        private IBaseRepository<Survey> Surveys { get; set; }
        


        public void Work()
        {
            GlobalDBContext context = new GlobalDBContext();
            Surveys = new BaseRepository<Survey>(context);

            var rand = new Random();
            int surveyId = 2;
            Survey survey1 = new Survey();
            //survey1.Id = surveyId;
            survey1.Name = "TestName";
            survey1.YearOfBirth = rand.Next();
            survey1.City = String.Format($"City{rand.Next()}");
            survey1.Country = String.Format($"Country{rand.Next()}");
            survey1.Phone = rand.Next();
            survey1.Email = "JustExample@mail.ru";

            Survey survey2 = Surveys.Create(survey1);



            var survey = Surveys.Get(surveyId);


        }
    }
}
