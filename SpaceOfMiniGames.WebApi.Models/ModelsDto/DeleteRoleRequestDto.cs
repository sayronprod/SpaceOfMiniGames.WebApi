using System.ComponentModel.DataAnnotations;

namespace SpaceOfMiniGames.WebApi.Models.ModelsDto
{
    public class DeleteRoleRequestDto
    {
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string RoleName { get; set; }
    }
}
