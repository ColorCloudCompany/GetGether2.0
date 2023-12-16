using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GetGetherIdentityServer.Models;


namespace GetGetherIdentityServer.Data
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUserConfiguration>
    { 
        public void Configure (EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
        }

        public void Configure(EntityTypeBuilder<AppUserConfiguration> builder)
        {
            throw new NotImplementedException();
        }
    }
}
