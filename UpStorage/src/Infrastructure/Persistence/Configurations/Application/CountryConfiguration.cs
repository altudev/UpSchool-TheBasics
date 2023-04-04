using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class CountryConfiguration:IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            // Id
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Name
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100);

            //Iso3
            builder.Property(c => c.Iso3).IsRequired(false);
            builder.Property(c => c.Iso3).HasColumnType("char(3)");

            //Iso2
            builder.Property(c => c.Iso2).IsRequired(false);
            builder.Property(c => c.Iso2).HasColumnType("char(2)");

            //Numeric Code
            builder.Property(c => c.NumericCode).IsRequired(false);
            builder.Property(c => c.NumericCode).HasColumnType("char(3)");

            //Phone Code
            builder.Property(c => c.PhoneCode).IsRequired(false);
            builder.Property(c => c.PhoneCode).HasMaxLength(50);

            //Capital
            builder.Property(c => c.Capital).IsRequired(false);
            builder.Property(c => c.Capital).HasMaxLength(100);

            //Currency
            builder.Property(c => c.Currency).IsRequired(false);
            builder.Property(c => c.Currency).HasColumnType("varchar(50)");

            //TId
            builder.Property(c => c.TId).IsRequired(false);
            builder.Property(c => c.TId).HasColumnType("varchar(10)");

            //Region
            builder.Property(c => c.Region).IsRequired(false);
            builder.Property(c => c.Region).HasColumnType("varchar(100)");

            //SubRegion
            builder.Property(c => c.SubRegion).IsRequired(false);
            builder.Property(c => c.SubRegion).HasColumnType("varchar(100)");

            //Latitude
            builder.Property(c => c.Latitude).IsRequired(false);
            builder.Property(c => c.Latitude).HasColumnType("decimal(10,8)");

            //Longitude
            builder.Property(c => c.Longitude).IsRequired(false);
            builder.Property(c => c.Longitude).HasColumnType("decimal(11,8)");

            //WikiDataId
            //https://www.wikidata.org/wiki/Q43
            builder.Property(c => c.WikiDataId).IsRequired(false);
            builder.Property(c => c.WikiDataId).HasColumnType("varchar(100)");

            /* Common Fields */

            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId).IsRequired(false);
            builder.Property(x => x.CreatedByUserId).HasMaxLength(100);

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            // ModifiedByUserId
            builder.Property(x => x.ModifiedByUserId).IsRequired(false);
            builder.Property(x => x.ModifiedByUserId).HasMaxLength(100);

            // LastModifiedOn
            builder.Property(x => x.ModifiedOn).IsRequired(false);

            // DeletedByUserId
            builder.Property(x => x.DeletedByUserId).IsRequired(false);
            builder.Property(x => x.DeletedByUserId).HasMaxLength(100);

            // DeletedOn
            builder.Property(x => x.DeletedOn).IsRequired(false);

            // IsDeleted
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValueSql("0");

            // Relationships
            builder.HasMany<City>(x => x.Cities)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.CountryId);

            builder.ToTable("Countries");
        }
    }
}
