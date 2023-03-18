using Microsoft.EntityFrameworkCore;
using UpSchool.Domain.Entities;
using UpSchool.Persistence.EntityFramework.Configurations;

namespace UpSchool.Persistence.EntityFramework.Contexts
{
    public class UpStorageDbContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }


        public UpStorageDbContext(DbContextOptions<UpStorageDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
