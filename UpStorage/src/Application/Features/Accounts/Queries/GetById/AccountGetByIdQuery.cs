using MediatR;

namespace Application.Features.Accounts.Queries.GetById
{
    public class AccountGetByIdQuery:IRequest<AccountGetByIdDto>
    {
        public Guid Id { get; set; }

        public AccountGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
