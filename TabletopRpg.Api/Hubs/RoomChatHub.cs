using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace TabletopRpg.Api.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RoomChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            var username = Context.User.Identity.Name;
            await Clients.Group(GetHubName()).SendAsync("SendMessage", username, message);
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