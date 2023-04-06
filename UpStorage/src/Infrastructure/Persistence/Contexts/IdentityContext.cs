using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities;

namespace Infrastructure.Persistence.Contexts
{
    public class IdentityContext:IdentityDbContext<User,Role,string,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
    {


        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Ignores
            modelBuilder.Ignore<Account>();
            modelBuilder.Ignore<Country>();
            modelBuilder.Ignore<City>();
            modelBuilder.Ignore<AccountCategory>();
            modelBuilder.Ignore<Category>();
            modelBuilder.Ignore<Address>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
