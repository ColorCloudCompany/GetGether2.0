﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GetGetherIdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace GetGetherIdentityServer.Data
{
    public class IdentityDBContext : IdentityDbContext<AppUser>
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(entity => entity.ToTable(name: "Users"));
            builder.Entity<IdentityRole>(entity => entity.ToTable(name: "Roles"));
            builder.Entity<IdentityUserRole<string>>(entity =>
            entity.ToTable(name: "UserRoles"));
            builder.Entity<IdentityUserClaim<string>>(entity =>
            entity.ToTable(name: "UserClaim"));
            builder.Entity<IdentityUserLogin<string>>(entity =>
            entity.ToTable(name: "UserLogins"));
            builder.Entity<IdentityUserToken<string>>(entity =>
            entity.ToTable(name: "UserTokens"));
            builder.Entity<IdentityUserClaim<string>>(entity =>
            entity.ToTable(name: "RoleClaims"));
            builder.ApplyConfiguration(new AppUserConfiguration());
        }
    }
}
