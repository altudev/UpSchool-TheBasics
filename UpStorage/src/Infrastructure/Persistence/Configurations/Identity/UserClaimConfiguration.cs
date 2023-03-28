using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Identity
{
    public class UserClaimConfiguration:IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(191);

            // Maps to the AspNetUserClaims table
            builder.ToTable("UserClaims");
        }
    }
}
