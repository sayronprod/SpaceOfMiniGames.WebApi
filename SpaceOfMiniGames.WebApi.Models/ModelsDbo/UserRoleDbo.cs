namespace SpaceOfMiniGames.WebApi.Models.ModelsDbo
{
    public class RoleRelationship
    {
        public int UserId { get; set; }
        public virtual UserDbo User { get; set; }
        public int RoleId { get; set; }
        public virtual RoleDbo Role { get; set; }
    }
}
