using Application.Features.Accounts.Commands.Add;
using Application.Features.Accounts.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs
{
    public class AccountHub:Hub
    {
        private ISender? _mediator;
        private readonly IHttpContextAccessor _contextAccessor;

        public AccountHub(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        protected ISender Mediator => _mediator ??= _contextAccessor.HttpContext.RequestServices.GetRequiredService<ISender>();
        [Authorize]
        public async Task<Guid> AddANewAccount(AccountAddCommand command)
        {
            var accessToken = Context.GetHttpContext().Request.Query["access_token"];

            var result = await Mediator.Send(command);

            var accountGetById =   await Mediator.Send(new AccountGetByIdQuery(result.Data));

            await Clients.All.SendAsync("NewAccountAdded", accountGetById, accessToken);

            return result.Data;
        }
    }
}
