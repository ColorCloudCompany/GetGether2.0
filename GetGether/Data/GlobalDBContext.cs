using GetGether.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GetGether.Data
{
    public class GlobalDBContext : IdentityDbContext<User>
    {
        //public GlobalDBContext(DbContextOptions<GlobalDBContext> options) : base(options) { }

        public GlobalDBContext()
        {
        }

        public GlobalDBContext(DbContextOptions<GlobalDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Здесь укажите строку подключения к вашей базе данных
                optionsBuilder.UseSqlServer("Server=.; Database=GetGether; Trusted_Connection=true; MultipleActiveResultSets=True; TrustServerCertificate=True");
            }
        }


        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Hobbi> Hobbies { get; set; }
    }
}





