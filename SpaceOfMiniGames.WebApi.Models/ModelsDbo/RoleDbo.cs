using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceOfMiniGames.WebApi.Models.ModelsDbo
{
    [Table("Roles")]
    public class RoleDbo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string RoleName { get; set; }
        public virtual ICollection<UserDbo> Users { get; set; }
        public virtual ICollection<RoleRelationship> RoleRelationships { get; set; }
    }
}
