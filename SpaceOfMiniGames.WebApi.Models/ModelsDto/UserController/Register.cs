using System.ComponentModel.DataAnnotations;

namespace SpaceOfMiniGames.WebApi.Models.ModelsDto.UserController
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Login { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Password { get; set; }
    }

    public class RegisterResponse : BaseResponse
    {
        public string Token { get; set; }
        public DateTime? Expired { get; set; }
        public User UserInfo { get; set; }
    }
}
