using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Identity
{
    public class UserTokenConfiguration:IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            // Composite primary key consisting of the UserId, LoginProvider and Name
            builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            // Limit the size of the composite key columns due to common DB restrictions
            builder.Property(t => t.LoginProvider).HasMaxLength(191);
            builder.Property(t => t.Name).HasMaxLength(191);

            // Maps to the AspNetUserTokens table
            builder.ToTable("UserTokens");
        }
    }
}
