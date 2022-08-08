namespace SpaceOfMiniGames.WebApi.Models.ModelsDto.UserController
{
    public class DeleteUserByLoginRequest
    {
        public string Login { get; set; }
    }

    public class DeleteUserByLoginResponse : BaseResponse
    {
    }
}
