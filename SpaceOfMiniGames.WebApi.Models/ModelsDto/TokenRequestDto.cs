using System.ComponentModel.DataAnnotations;

namespace SpaceOfMiniGames.WebApi.Models.ModelsDto
{
    public class TokenRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Login { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Password { get; set; }
    }
}
