using Domain.Common;
using MediatR;

namespace Application.Features.Accounts.Commands.Remove
{
    public class AccountRemoveCommand:IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }

        public AccountRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
