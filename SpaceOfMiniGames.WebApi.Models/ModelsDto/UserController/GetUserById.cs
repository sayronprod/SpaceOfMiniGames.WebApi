namespace SpaceOfMiniGames.WebApi.Models.ModelsDto.UserController
{
    public class GetUserByIdRequest
    {
        public int Id { get; set; }
    }

    public class GetUserByIdResponse : BaseResponse
    {
        public User User { get; set; }
    }
}
