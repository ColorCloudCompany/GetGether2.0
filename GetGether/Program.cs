using GetGether.Auth;
using GetGether.Data;
using GetGether.Models;
using GetGether.Repository.Implimentation;
using GetGether.Repository.Interfaces;
using GetGether.Services.Implimentation;
using GetGether.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GetGether
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var people = new List<User>
                        {
                new User("tom@gmail.com", "12345"),
                new User("bob@gmail.com", "55555")
            };

            var builder = WebApplication.CreateBuilder(args);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddDbContext<GlobalDBContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });

            //        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //.AddCookie();

            builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                }).AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        RequireExpirationTime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:7293/",
                        ValidAudience = "https://localhost:7293/",
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
                    };
                });




            builder.Services.AddAuthorization();

            builder.Services.AddScoped<ITestService, TestService>();
            builder.Services.AddScoped<IBaseRepository<Survey>, BaseRepository<Survey>>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                    policy =>
                                    {
                                        policy.WithOrigins("http://localhost:3000")
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .AllowCredentials();
                                    });
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);


            //builder.Services.AddTransient<ITestService, TestService>();
            //builder.Services.AddTransient<IBaseRepository<Survey>, BaseRepository<Survey>>();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();


            //app.Map("/login/{username}", (string username) =>
            //{
            //    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
            //    var jwt = new JwtSecurityToken(
            //            issuer: AuthOptions.ISSUER,
            //            audience: AuthOptions.AUDIENCE,
            //            claims: claims,
            //            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            //            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            //    return new JwtSecurityTokenHandler().WriteToken(jwt);
            //});

            app.Map("/", (HttpContext context) =>
            {
                var user = context.User.Identity;
                if (user is not null && user.IsAuthenticated)
                    return $"UserName: {user.Name}";
                else return "user not auth";
            });
            app.MapGet("/logout", async (HttpContext context) =>
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return "Datas is deleted";
            });

            app.MapPut("/data", [Authorize] (HttpContext context) =>
            {
                return $"Hello World!";
            });

            app.MapPost("/login", (User loginData) =>
            {
                // находим пользователя 
                User? user = people.FirstOrDefault(p => p.Email == loginData.Email && p.Password == loginData.Password);
                // если пользователь не найден, отправляем статусный код 401
                if (user is null) return Results.Unauthorized();

                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: "https://localhost:7293/",
                        audience: "https://localhost:7293/",
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                // формируем ответ
                var response = new
                {
                    access_token = encodedJwt,
                    username = user.Email
                };

                return Results.Json(response);
            });

            app.Run();
        }
    }
}