namespace SpaceOfMiniGames.WebApi.Models
{
    public class TokenModel
    {
        public string UserLogin { get; set; }
        public DateTime Expired { get; set; }
    }
}
