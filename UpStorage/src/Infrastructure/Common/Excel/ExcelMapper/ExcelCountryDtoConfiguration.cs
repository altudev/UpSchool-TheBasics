using Application.Common.Models.Excel;
using ExcelMapper;

namespace Infrastructure.Common.Excel.ExcelMapper
{
    public class ExcelCountryDtoConfiguration : ExcelClassMap<ExcelCountryDto>
    {
        public ExcelCountryDtoConfiguration()
        {

            Map(c => c.Id)
                .WithColumnIndex(0);


            Map(c => c.Name)
                .WithColumnIndex(1);

            Map(c => c.Iso2)
                .WithColumnIndex(2)
                .WithInvalidFallback(null);

            Map(c => c.Iso3)
                .WithColumnIndex(3)
                .WithInvalidFallback(null);

            Map(c => c.NumericCode)
                .WithColumnIndex(4)
                .WithInvalidFallback(null);

            Map(c => c.PhoneCode)
                .WithColumnIndex(5)
                .WithInvalidFallback(null);

            Map(c => c.Capital)
                .WithColumnIndex(6)
                .WithInvalidFallback(null);


            Map(c => c.Currency)
                .WithColumnIndex(7)
                .WithInvalidFallback(null);

            Map(c => c.TId)
                .WithColumnIndex(8)
                .WithInvalidFallback(null);

            Map(c => c.Region)
                .WithColumnIndex(9)
                .WithInvalidFallback(null);
            Map(c => c.SubRegion)
                .WithColumnIndex(10)
                .WithInvalidFallback(null);


            Map(c => c.Latitude)
                .WithColumnIndex(11)
                .WithInvalidFallback(null);

            Map(c => c.Longitude)
                .WithColumnIndex(12)
                .WithInvalidFallback(null);
            Map(c => c.WikiDataId)
                .WithColumnIndex(13)
                .WithInvalidFallback(null);

        }

    }
}
