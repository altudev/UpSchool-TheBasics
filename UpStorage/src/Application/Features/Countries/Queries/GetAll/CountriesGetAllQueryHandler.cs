using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Countries.Queries.GetAll
{
    public class CountriesGetAllQueryHandler:IRequestHandler<CountriesGetAllQuery,List<CountriesGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CountriesGetAllQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<List<CountriesGetAllDto>> Handle(CountriesGetAllQuery request, CancellationToken cancellationToken)
        {
            return _applicationDbContext
                .Countries
                .Select(x => new CountriesGetAllDto(x.Id, x.Name))
                .ToListAsync(cancellationToken);
        }
    }
}
