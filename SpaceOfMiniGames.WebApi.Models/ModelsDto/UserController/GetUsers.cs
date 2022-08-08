namespace SpaceOfMiniGames.WebApi.Models.ModelsDto.UserController
{
    public class GetUsersResponse : BaseResponse
    {
        public ICollection<User> Users { get; set; }
    }
}
