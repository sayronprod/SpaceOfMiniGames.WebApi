using System.ComponentModel.DataAnnotations;

namespace SpaceOfMiniGames.WebApi.Models.ModelsDto.UserController
{
    public class GrantRoleToUserByIdRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string RoleName { get; set; }
    }

    public class GrantRoleToUserByIdResponse : BaseResponse
    {

    }
}
