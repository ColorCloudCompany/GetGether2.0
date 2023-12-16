using IdentityServer4.Models;
using IdentityServer4;
using GetGetherIdentityServer.Configuration;
using GetGetherIdentityServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GetGetherIdentityServer.Models;

namespace GetGetherIdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {

           
           var builder = WebApplication.CreateBuilder(args);

            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<IdentityDBContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception except)
                {

                    var logger = serviceProvider .GetRequiredService<ILogger<Program>>();
                    logger.LogError(except, "An error occurred  while app initialization ");
                }
            }

            builder.Services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 128;
                config.Password.RequireDigit = false;
                config.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<IdentityDBContext>()
            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "test";
                config.LoginPath = "/";
                config.LogoutPath = "/";
            });

            builder.Services.AddDbContext<IdentityDBContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });

            builder.Services.AddIdentityServer()
                .AddAspNetIdentity<AppUser>()
                .AddInMemoryApiResources(Config.ApiResources)
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiScopes(Config.ApiScope)
                .AddInMemoryClients(Config.Clients)
                .AddDeveloperSigningCredential();

   

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            app.UseIdentityServer();

            app.Run();
        }
    }
}