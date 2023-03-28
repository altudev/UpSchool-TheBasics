using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Identity
{
    public class RoleClaimConfiguration:IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            // Primary key
            builder.HasKey(rc => rc.Id);
            builder.Property(x => x.Id).HasMaxLength(191);

            // Maps to the AspNetRoleClaims table
            builder.ToTable("RoleClaims");
        }
    }
}
