using GetGether.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace GetGether.Data
{
    public class GlobalDBContext : IdentityDbContext
    {

        public GlobalDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany(p => p.Events)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(e => e.OrganizerUserNameId);

            modelBuilder.Entity<EventParticipant>()
               .HasKey(ep => new {ep.EventId, ep.ProfileUserNameId});

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Event)
                .WithMany(e => e.EventParticipants) 
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(ep =>  ep.EventId);

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Profile)
                .WithMany(e => e.EventParticipants)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(ep => ep.ProfileUserNameId);
        }




        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Event> Events { get; set; }

        
    }
}





