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
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public TokenController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<TokenResponse> Token(TokenRequest request)
        {
            bool authResult = await _userService.AuthorizeUser(request.Login, request.Password);

            TokenResponse response = new TokenResponse();

            if (authResult)
            {
                (string, DateTime) tokenResult = _tokenService.GetToken(request.Login);
                User user = await _userService.GetUserByLogin(request.Login);
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