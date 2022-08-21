using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaceOfMiniGames.WebApi.Models;
using SpaceOfMiniGames.WebApi.Models.Interfaces;
using SpaceOfMiniGames.WebApi.Models.ModelsDto.UserController;

namespace SpaceOfMiniGames.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            User createdUser = await _userService.CreateUser(request.Login, request.Password);

            RegisterResponse response = new RegisterResponse();

            if (createdUser is null)
            {
                response.SetFail($"User with login {request.Login} already exist");
            }
            else
            {
                (string, DateTime) tokenResult = _tokenService.GetToken(request.Login);
                response.Token = tokenResult.Item1;
                response.Expired = tokenResult.Item2;
                response.UserInfo = createdUser;
                response.SetSuccess();
            }

            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<UpdatePasswordResponse> UpdatePassword(UpdatePasswordRequest request)
        {
            bool updatedResult = await _userService.UpdateUserPassword(request.Login, request.OldPassword, request.NewPassword);

            UpdatePasswordResponse response = new UpdatePasswordResponse();

            if (!updatedResult)
            {
                response.SetFail("Error password update");
            }
            else
            {
                response.SetSuccess();
            }

            return response;
        }

        [HttpPost]
        public async Task<GetUsersResponse> GetUsers()
        {
            var users = await _userService.GetUsers();

            GetUsersResponse response = new GetUsersResponse();
            response.Users = users;
            response.SetSuccess();

            return response;
        }

        [HttpPost]
        public async Task<GetUserByIdResponse> GetUserById(GetUserByIdRequest request)
        {
            var user = await _userService.GetUserById(request.Id);

            GetUserByIdResponse response = new GetUserByIdResponse();

            if (user is null)
            {
                response.SetFail("User not found");
            }
            else
            {
                response.User = user;
                response.SetSuccess();
            }

            return response;
        }

        [HttpPost]
        public async Task<GetUserByLoginResponse> GetUserByLogin(GetUserByLoginRequest request)
        {
            var user = await _userService.GetUserByLogin(request.Login);

            GetUserByLoginResponse response = new GetUserByLoginResponse();

            if (user is null)
            {
                response.SetFail("User not found");
            }
            else
            {
                response.User = user;
                response.SetSuccess();
            }

            return response;
        }

        [HttpPost]
        public async Task<DeleteUserByIdResponse> DeleteUserById(DeleteUserByIdRequest request)
        {
            await _userService.DeleteUserById(request.Id);

            DeleteUserByIdResponse response = new DeleteUserByIdResponse();
            response.SetSuccess();

            return response;
        }

        [HttpPost]
        public async Task<DeleteUserByLoginResponse> DeleteUserByLogin(DeleteUserByLoginRequest request)
        {
            await _userService.DeleteUserByLogin(request.Login);

            DeleteUserByLoginResponse response = new DeleteUserByLoginResponse();
            response.SetSuccess();

            return response;
        }

        [HttpPost]
        public async Task<GrantRoleToUserByIdResponse> GrantRoleToUserById(GrantRoleToUserByIdRequest request)
        {
            (bool, string) grantResult = await _userService.GrantRoleToUserById(request.UserId, request.RoleName);

            GrantRoleToUserByIdResponse response = new GrantRoleToUserByIdResponse();
            response.IsSuccess = grantResult.Item1;
            response.Message = grantResult.Item2;

            return response;
        }

        [HttpPost]
        public async Task<GrantRoleToUserByLoginResponse> GrantRoleToUserByLogin(GrantRoleToUserByLoginRequest request)
        {
            (bool, string) grantResult = await _userService.GrantRoleToUserByLogin(request.UserLogin, request.RoleName);

            GrantRoleToUserByLoginResponse response = new GrantRoleToUserByLoginResponse();
            response.IsSuccess = grantResult.Item1;
            response.Message = grantResult.Item2;

            return response;
        }

        [HttpPost]
        public async Task<DeleteRoleInUserByIdResponse> DeleteRoleInUserById(DeleteRoleInUserByIdRequest request)
        {
            bool deleteResult = await _userService.DeleteRoleInUserById(request.UserId, request.RoleName);

            DeleteRoleInUserByIdResponse response = new DeleteRoleInUserByIdResponse();
            response.IsSuccess = deleteResult;
            response.Message = "";

            return response;
        }

        [HttpPost]
        public async Task<DeleteRoleInUserByLoginResponse> DeleteRoleInUserByLogin(DeleteRoleInUserByLoginRequest request)
        {
            bool deleteResult = await _userService.DeleteRoleInUserByLogin(request.UserLogin, request.RoleName);

            DeleteRoleInUserByLoginResponse response = new DeleteRoleInUserByLoginResponse();
            response.IsSuccess = deleteResult;
            response.Message = "";

            return response;
        }
    }
}
