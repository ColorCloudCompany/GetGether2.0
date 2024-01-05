using GetGether.Data;
using GetGether.Models;

namespace GetGether.Services.Implimentation
{
    public class AddTestDatas
    {

        private readonly GlobalDBContext _dbContext;
        private readonly IAuthService _authService;

        public static List<RegisterUser> TestRegisterUsers = new List<RegisterUser>();
        public static List<EventParticipant> EventParticipants = new List<EventParticipant>();
        public static List<Event> TestEvents = new List<Event>();
        public static List<Profile> TestProfiles = new List<Profile>();

        public AddTestDatas(GlobalDBContext dbContext, IAuthService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }



        public void CreateEvents()
        {

            List<Event> events = new List<Event>
            {
                new Event()
                {
                    EventName = "Birthday Bash",
                    OrganizerUserNameId = "SuderBob1@gmail.com",
                    Organizer = TestRegisterUsers[0].UserProfile,
                    Description = "Join us for an unforgettable birthday celebration for John! An evening filled with music, laughter, and joy awaits."
                 },
                new Event()
                 {
                    EventName = "Company Retreat",
                    OrganizerUserNameId = "SuderBob2@gmail.com",
                    Organizer = TestRegisterUsers[1].UserProfile,
                    Description = "Get ready for our annual company retreat! A weekend of team-building activities, workshops, and relaxation."
                 },
                 new Event()
                 {
                    EventName = "Charity Fundraiser",
                    OrganizerUserNameId = "SuderBob3@gmail.com",
                    Organizer = TestRegisterUsers[2].UserProfile,
                    Description = "Join hands for a noble cause! Our charity fundraiser aims to make a difference in the lives of those in need."
                 },
                  new Event()
                 {
                    EventName = "Charity Fundraiser",
                    OrganizerUserNameId = "SuderBob4@gmail.com",
                    Organizer = TestRegisterUsers[3].UserProfile,
                    Description = "Join hands for a noble cause! Our charity fundraiser aims to make a difference in the lives of those in need."
                 },
                 new Event()
                {
                    EventName = "test",
                    OrganizerUserNameId = "SuderBob5@gmail.com",
                    Organizer = TestRegisterUsers[4].UserProfile,
                    Description = "Join us for a jubilant celebration honoring Spartak's triumph! Revel in an evening of camaraderie and festivity as we commemorate the victory achieved by the Spartak team. Let's come together to rejoice, reminisce, and create unforgettable memories in tribute to their success!",
                 }
            };

            TestEvents.AddRange(events);

        }

        public void CreateUsers()
        {

           

           TestRegisterUsers.Add(new RegisterUser()
            {
                UserName = "SuderBob1@gmail.com",
                Password = "12Fg$",
                UserProfile = new Profile()
                {
                    UserNameId = "string1",
                    Name = "Bob1",
                    Age = 20
                }
            });

            TestRegisterUsers.Add(new RegisterUser()
            {
                UserName = "SuderBob2@gmail.com",
                Password = "12Fg$",
                UserProfile = new Profile()
                {
                    UserNameId = "string2",
                    Name = "Bob2",
                    Age = 20
                }
            });

            TestRegisterUsers.Add(new RegisterUser()
            {
                UserName = "SuderBob3@gmail.com",
                Password = "12Fg$",
                UserProfile = new Profile()
                {
                    UserNameId = "string3",
                    Name = "Bob3",
                    Age = 20
                }
            });

            TestRegisterUsers.Add(new RegisterUser()
            {
                UserName = "SuderBob4@gmail.com",
                Password = "12Fg$",
                UserProfile = new Profile()
                {
                    UserNameId = "string4",
                    Name = "Bob4",
                    Age = 20
                }
            });

            TestRegisterUsers.Add(new RegisterUser()
            {
                UserName = "SuderBob5@gmail.com",
                Password = "12Fg$",
                UserProfile = new Profile()
                {
                    UserNameId = "string5",
                    Name = "Bob5",
                    Age = 20
                }
            });
        }

        public void CreateProfiles()
        {

        }

        public void CreateConnections()
        {
            EventParticipants.Add(new EventParticipant()
            {
                EventId = TestEvents[0].Id,
                Event = TestEvents[0],
                ProfileUserNameId = TestRegisterUsers[0].UserProfile.UserNameId,
                Profile = TestRegisterUsers[0].UserProfile
            });

            EventParticipants.Add(new EventParticipant()
            {
                EventId = TestEvents[1].Id,
                Event = TestEvents[1],
                ProfileUserNameId = TestRegisterUsers[1].UserProfile.UserNameId,
                Profile = TestRegisterUsers[1].UserProfile
            });

            EventParticipants.Add(new EventParticipant()
            {
                EventId = TestEvents[2].Id,
                Event = TestEvents[2],
                ProfileUserNameId = TestRegisterUsers[2].UserProfile.UserNameId,
                Profile = TestRegisterUsers[2].UserProfile
            });

            EventParticipants.Add(new EventParticipant()
            {
                EventId = TestEvents[3].Id,
                Event = TestEvents[3],
                ProfileUserNameId = TestRegisterUsers[3].UserProfile.UserNameId,
                Profile = TestRegisterUsers[3].UserProfile
            });

            EventParticipants.Add(new EventParticipant()
            {
                EventId = TestEvents[4].Id,
                Event = TestEvents[4],
                ProfileUserNameId = TestRegisterUsers[4].UserProfile.UserNameId,
                Profile = TestRegisterUsers[4].UserProfile
            });


        }

        public bool AddDataToDataBase()
        {

           



                CreateUsers();
                CreateEvents();
                CreateConnections();

                for (int i = 0; i < 5; i++)
                {
                    TestRegisterUsers[i].UserProfile.Events.Add(TestEvents[i]);
                    TestRegisterUsers[i].UserProfile.EventParticipants.Add(EventParticipants[i]);
                    TestEvents[i].EventParticipants.Add(EventParticipants[i]);
                }


                for (int i = 0; i < 5; i++)
                {
                    _authService.RegisterUser(TestRegisterUsers[i]);
                }
                
               


                TestProfiles = _dbContext.Profiles.ToList();
                CreateConnections();


                for (int i = 0; i < 5; i++)
                {
                    _dbContext.Events.Add(TestEvents[i]);
                    _dbContext.SaveChanges();// Сохранение изменений в базе данных

                }
                
               
            
            

            return true;
            
        }
    }
}
