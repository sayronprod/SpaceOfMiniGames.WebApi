using System.ComponentModel.DataAnnotations;

namespace SpaceOfMiniGames.WebApi.Models.ModelsDto
{
    public class UpdatePasswordRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Login { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string OldPassword { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string NewPassword { get; set; }
    }
}
