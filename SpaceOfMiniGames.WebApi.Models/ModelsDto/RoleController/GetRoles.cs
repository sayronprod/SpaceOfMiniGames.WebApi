namespace SpaceOfMiniGames.WebApi.Models.ModelsDto.RoleController
{
    public class GetRolesResponse : BaseResponse
    {
        public ICollection<string> Roles { get; set; }
    }
}
