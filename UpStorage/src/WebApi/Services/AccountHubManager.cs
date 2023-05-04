using Application.Common.Interfaces;
using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs;

namespace WebApi.Services
{
    public class AccountHubManager:IAccountHubService
    {
        private readonly IHubContext<AccountHub> _hubContext;

        public AccountHubManager(IHubContext<AccountHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task RemovedAsync(Guid id, CancellationToken cancellationToken)
        {
            return  _hubContext.Clients.All.SendAsync("Removed", id, cancellationToken);
        }
    }
}
