using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace SpaceOfMiniGames.WebApi.Hubs
{
    [Authorize]
    public class GameHub : Hub<IGameHub>
    {
        public override Task OnConnectedAsync()
        {
            var user = Context.UserIdentifier;
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            await Clients.Others.ReceiveMessage(message);
        }

        public async Task SendGameData(object data)
        {
            await Clients.Others.ReceiveGameData(data);
        }
    }
}
