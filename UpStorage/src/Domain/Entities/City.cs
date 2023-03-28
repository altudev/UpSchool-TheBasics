using Domain.Common;

namespace Domain.Entities
{
    public class City:EntityBase<int>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }

    
}
