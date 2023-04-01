using MediatR;

namespace Application.Features.Cities.Queries.GetAll
{
    public class CityGetAllQuery:IRequest<List<CityGetAllDto>>
    {
        public int CountryId { get; set; }
        public bool? IsDeleted { get; set; }

        public CityGetAllQuery(int countryId, bool? isDeleted)
        {
            CountryId = countryId;

            IsDeleted = isDeleted;
        }
    }
}
