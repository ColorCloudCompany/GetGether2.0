//using System.ComponentModel.DataAnnotations.Schema;
//using System;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using GetGether.Models;


//namespace GetGether.Data
//{
//    public class GlobalDbContext : DbContext
//    {
//        public GlobalDbContext()
//        {
//        }

//        public GlobalDbContext(DbContextOptions<GlobalDbContext> options) : base(options)
//        {

//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                // Здесь укажите строку подключения к вашей базе данных
//                optionsBuilder.UseSqlServer("Server=.; Database=GetGether; Trusted_Connection=true; MultipleActiveResultSets=True; TrustServerCertificate=True");
//            }
//        }


//        public DbSet<Survey> Surveys { get; set; }
//        public DbSet<Hobbi> Hobbies { get; set; }


//    }

//}
