//using Microsoft.AspNetCore.Identity;
//using GetGether.Models;
//using System.Reflection.Emit;

//namespace GetGether.Data
//{
//    public class DataSeed
//    {
//        public static async Task SeedDataAsync(GlobalDBContext context, UserManager userManager)
//        {
//            if (!userManager.Users.Any())
//            {
//                var users = new List<User>
//                            {
//                                new User
//                                {
//                                        ZipCode = "User1Zip"
//                                    },

//                                new User
//                                    {
//                                        ZipCode = "User2Zip"
//                                    }
//                              };

//                foreach (var user in users)
//                {
//                    await userManager.CreateAsync(user, "qazwsX123@");
//                }
//            }
//        }
//    }
//}
