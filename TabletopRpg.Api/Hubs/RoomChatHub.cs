using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TabletopRpg.Api.Hubs
{
    public class RoomChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.Group(GetHubName()).SendAsync("SendMessage", "username", message);
        }

        public async Task Join()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GetHubName());
        }

        public async Task Leave()
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, GetHubName());
        }
        
        public virtual string GetHubName() => "ChatTeste";

        
    }
}