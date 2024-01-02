using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace GetGether.Models
{
    public class LoginUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }

    public class RegisterUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Profile UserProfile { get; set; }
    }
}
