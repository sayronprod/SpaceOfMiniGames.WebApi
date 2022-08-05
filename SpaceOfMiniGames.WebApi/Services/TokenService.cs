using SpaceOfMiniGames.WebApi.Data;
using SpaceOfMiniGames.WebApi.Domain;
using SpaceOfMiniGames.WebApi.Models;
using SpaceOfMiniGames.WebApi.Models.Interfaces;

namespace SpaceOfMiniGames.WebApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly ISecureService secureService;
        private readonly ApplicationSettings applicationSettings;

        private int tokenLifeTime => applicationSettings.tokenLifeTime;

        public TokenService(ISecureService secureService, ApplicationSettings applicationSettings)
        {
            this.secureService = secureService;
            this.applicationSettings = applicationSettings;
        }

        public string DecryptToken(string token)
        {
            return secureService.Decrypt(token);
        }

        public (string, DateTime) GetToken(string userLogin)
        {
            DateTime Expired = DateTime.Now.AddHours(tokenLifeTime);
            TokenModel tokenModel = new TokenModel
            {
                UserLogin = userLogin,
                Expired = Expired
            };

            var json = tokenModel.Serialize();
            var result = secureService.Encrypt(json);
            return (result, Expired);
        }
    }
}
