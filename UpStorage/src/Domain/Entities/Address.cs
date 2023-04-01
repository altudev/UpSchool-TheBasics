using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Address:EntityBase<Guid>
    {
        public string Name { get; set; }
        public string UserId { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public string District { get; set; }
        public string PostCode { get; set; }

        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }

        public AddressType AddressType { get; set; }
    }
}
