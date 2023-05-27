using MediatR;

namespace Application.Features.Accounts.Queries.GetAll
{
    public class AccountGetAllQuery:IRequest<List<AccountGetAllDto>>
    {

    }
}
