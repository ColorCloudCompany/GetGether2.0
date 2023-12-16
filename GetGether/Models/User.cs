using Microsoft.AspNetCore.Identity;


namespace GetGether.Models
{
    public class User : IdentityUser
    {
        public User(string email, string password)
        { 
            Email = email;
            Password = password;
        }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
