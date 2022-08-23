namespace SpaceOfMiniGames.WebApi.Hubs
{
    public interface IGameHub
    {
        public Task ReceiveMessage(string message);
        public Task ReceiveGameData(object data);
        public Task NewUserConnectedToGame();
        public Task ReceiveNewBackground(object data);
    }
}
