using Microsoft.AspNetCore.DataProtection;
using SpaceOfMiniGames.WebApi.Data;
using SpaceOfMiniGames.WebApi.Models.Interfaces;

namespace SpaceOfMiniGames.WebApi.Services
{
    public class SecureService : ISecureService
    {
        private readonly IDataProtector _dataProtector;

        public SecureService(IDataProtectionProvider dataProtectionProvider, ApplicationSettings applicationSettings)
        {
            _dataProtector = dataProtectionProvider.CreateProtector(applicationSettings.SecretKey);
        }

        public string Encrypt(string input)
        {
            return _dataProtector.Protect(input);
        }

        public string Decrypt(string cipherText)
        {
            return _dataProtector.Unprotect(cipherText);
        }
    }
}
