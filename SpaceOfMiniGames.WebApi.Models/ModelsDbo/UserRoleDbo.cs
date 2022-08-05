using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceOfMiniGames.WebApi.Models.ModelsDbo
{
    [Table("UserRoles")]
    public class UserRoleDbo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RoleName { get; set; }
        public UserDbo User { get; set; }
    }
}
