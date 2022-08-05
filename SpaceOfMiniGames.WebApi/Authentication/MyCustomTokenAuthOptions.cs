using Microsoft.AspNetCore.Authentication;

namespace SpaceOfMiniGames.WebApi.Authentication
{
    public class MyCustomTokenAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScemeName = "MyCustomTokenAuthenticationScheme";
        public string TokenHeaderName { get; set; } = "Authorization";
    }
}
