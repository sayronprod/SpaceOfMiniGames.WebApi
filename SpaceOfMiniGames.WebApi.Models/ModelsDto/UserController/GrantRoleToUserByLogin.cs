using System.ComponentModel.DataAnnotations;

namespace SpaceOfMiniGames.WebApi.Models.ModelsDto.UserController
{
    public class GrantRoleToUserByLoginRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string UserLogin { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string RoleName { get; set; }
    }

    public class GrantRoleToUserByLoginResponse : BaseResponse
    {

    }
}
