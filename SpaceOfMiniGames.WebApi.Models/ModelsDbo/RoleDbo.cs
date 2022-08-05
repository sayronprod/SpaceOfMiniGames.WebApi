using System.ComponentModel.DataAnnotations;

namespace SpaceOfMiniGames.WebApi.Models.ModelsDbo
{
    public class RoleDbo
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
