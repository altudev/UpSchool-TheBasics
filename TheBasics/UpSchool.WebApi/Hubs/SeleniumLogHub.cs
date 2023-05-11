using Microsoft.AspNetCore.SignalR;
using UpSchool.Domain.Dtos;

namespace UpSchool.WebApi.Hubs
{
    public class SeleniumLogHub:Hub
    {
        public async Task SendLogNotificationAsync(SeleniumLogDto log)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("NewSeleniumLogAdded", log);
        }
    }
}
