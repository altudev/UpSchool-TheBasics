using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cities.Queries.GetAll
{
    public class CityGetAllQueryHandler:IRequestHandler<CityGetAllQuery,List<CityGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CityGetAllQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<CityGetAllDto>> Handle(CityGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.Cities.AsQueryable();

            dbQuery = dbQuery.Where(x => x.CountryId == request.CountryId);

            if (request.IsDeleted.HasValue) dbQuery = dbQuery.Where(x => x.IsDeleted == request.IsDeleted.Value);

            dbQuery = dbQuery.Include(x => x.Country);

            var cities = await dbQuery.ToListAsync(cancellationToken);

            var cityDtos = MapCitiesToGetAllDtos(cities);

            return cityDtos.ToList();
        }

        private IEnumerable<CityGetAllDto> MapCitiesToGetAllDtos(List<City> cities)
        {
            List<CityGetAllDto> cityGetAllDtos = new List<CityGetAllDto>();

            foreach (var city in cities)
            {

                yield return new CityGetAllDto()
                {
                    Id = city.Id,
                    CountryId = city.CountryId,
                    CountryName = city.Country.Name,
                    Name = city.Name,
                    IsDeleted = city.IsDeleted,
                    Longitude = city.Longitude,
                    Latitude = city.Latitude
                };
            }
        }
    }
}
