using System.ComponentModel.DataAnnotations;

namespace SpaceOfMiniGames.WebApi.Models.ModelsDto.RoleController
{
    public class DeleteRoleRequest
    {
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string RoleName { get; set; }
    }

    public class DeleteRoleResponse : BaseResponse
    {
    }
}
