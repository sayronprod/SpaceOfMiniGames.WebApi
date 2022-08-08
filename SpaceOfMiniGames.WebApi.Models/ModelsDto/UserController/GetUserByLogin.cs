namespace SpaceOfMiniGames.WebApi.Models.ModelsDto.UserController
{
    public class GetUserByLoginRequest
    {
        public string Login { get; set; }
    }

    public class GetUserByLoginResponse : BaseResponse
    {
        public User User { get; set; }
    }
}
