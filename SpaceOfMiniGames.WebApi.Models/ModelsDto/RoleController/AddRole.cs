using System.ComponentModel.DataAnnotations;

namespace SpaceOfMiniGames.WebApi.Models.ModelsDto.RoleController
{
    public class AddRoleRequest
    {
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string RoleName { get; set; }
    }

    public class AddRoleResponse : BaseResponse
    {
    }
}
