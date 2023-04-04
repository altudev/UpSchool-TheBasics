using Domain.Entities;

namespace Application.Common.Models.Excel
{
    public class ExcelCountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Iso2 { get; set; }
        public string? Iso3 { get; set; }
        public string? NumericCode { get; set; }
        public string? PhoneCode { get; set; }
        public string? Capital { get; set; }
        public string? Currency { get; set; }
        public string? TId { get; set; }
        public string? Region { get; set; }
        public string? SubRegion { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? WikiDataId { get; set; }

        public Country MapToCountry()
        {
            return new Country()
            {
                Id = this.Id,
                Name = this.Name,
                Iso2 = this.Iso2,
                Iso3 = this.Iso3,
                NumericCode = this.NumericCode,
                PhoneCode = this.PhoneCode,
                Capital = this.Capital,
                Currency = this.Currency,
                TId = this.TId,
                Region = this.Region,
                SubRegion = this.SubRegion,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                WikiDataId = this.WikiDataId,
            };
        }
    }
}
