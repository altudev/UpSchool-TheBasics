using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Id
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).HasMaxLength(191);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");

            //Firstname
            builder.Property(user => user.FirstName).IsRequired();
            builder.Property(user => user.FirstName).HasMaxLength(50);
            
            //Lastname
            builder.Property(user => user.LastName).IsRequired();
            builder.Property(user => user.LastName).HasMaxLength(50);

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(100);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(100);
            
            //Email
            builder.Property(u => u.Email).IsRequired();
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(100);

            //PhoneNumber
            builder.Property(u => u.PhoneNumber).IsRequired(false);
            builder.Property(u => u.PhoneNumber).HasMaxLength(20);


            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            //Each User can have many UserTokens

            // CreatedDate
            builder.Property(x => x.CreatedOn).IsRequired();
            
            // CreatedByUserId
            builder.Property(user => user.CreatedByUserId).IsRequired(false);
            
            // ModifiedDate
            builder.Property(user => user.ModifiedOn).IsRequired(false);
            
            // ModifiedByUserId
            builder.Property(user => user.ModifiedByUserId).IsRequired(false);
            

            builder.ToTable("Users");
        }
    }
}