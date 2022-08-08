using Microsoft.AspNetCore.Mvc;
using SpaceOfMiniGames.WebApi.Models;
using SpaceOfMiniGames.WebApi.Models.Interfaces;
using SpaceOfMiniGames.WebApi.Models.ModelsDto.TokenController;

namespace SpaceOfMiniGames.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : BaseApiController
    {
        private readonly ILogger<TokenController> logger;
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public TokenController(ILogger<TokenController> logger, IUserService userService, ITokenService tokenService)
        {
            this.logger = logger;
            this.userService = userService;
            this.tokenService = tokenService;
        }

        [HttpPost]
        public async Task<TokenResponse> Token(TokenRequest request)
        {
            bool authResult = await userService.AuthorizeUser(request.Login, request.Password);

            TokenResponse response = new TokenResponse();

            if (authResult)
            {
                (string, DateTime) tokenResult = tokenService.GetToken(request.Login);
                User user = await userService.GetUserByLogin(request.Login);
                response.Token = tokenResult.Item1;
                response.Expired = tokenResult.Item2;
                response.UserInfo = user;
                response.SetSuccess();
            }
            else
            {
                response.SetFail("Incorrect authorization data");
            }

            return response;
        }
    }
}