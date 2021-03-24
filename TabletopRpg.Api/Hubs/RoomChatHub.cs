using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TabletopRpg.Api.Hubs
{
    public class RoomChatHub : Hub
    {
        private string _roomChat = "RoomChat";

        public async Task SendMessage(string message)
        {
            await Clients.OthersInGroup(_roomChat).SendAsync("NewMessage", "username", message);
        }
    }
}