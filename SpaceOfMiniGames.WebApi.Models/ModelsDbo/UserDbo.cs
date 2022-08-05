using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceOfMiniGames.WebApi.Models.ModelsDbo
{
    [Table("Users")]
    public class UserDbo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Login { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<RoleDbo> UserRoles { get; set; }
        public virtual ICollection<RoleRelationship> RoleRelationships { get; set; }
    }
}
