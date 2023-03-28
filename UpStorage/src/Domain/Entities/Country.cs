using Domain.Common;

namespace Domain.Entities
{
    public class Country:EntityBase<int>
    {
        public string Name { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public string NumericCode { get; set; }
        public string PhoneCode { get; set; }
        public string Capital { get; set; }
        public string Currency { get; set; }
        public string TId { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string WikiDataId { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
