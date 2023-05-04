using MediatR;

namespace Application.Features.Countries.Queries.GetAll
{
    public class CountriesGetAllQuery:IRequest<List<CountriesGetAllDto>>
    {

    }
}
