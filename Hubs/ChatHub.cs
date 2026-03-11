using Microsoft.AspNetCore.SignalR;

using Microsoft.AspNetCore.SignalR;

namespace SmartCampusPortal.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}