using System.ComponentModel.DataAnnotations;

namespace SpaceOfMiniGames.WebApi.Models.ModelsDbo
{
    public class UserDbo
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<RoleDbo> UserRoles { get; set; }
    }
}
