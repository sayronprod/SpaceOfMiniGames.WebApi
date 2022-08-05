using SpaceOfMiniGames.WebApi.Models.ModelsDbo;

namespace SpaceOfMiniGames.WebApi.Models.Interfaces
{
    public interface IRoleRepository
    {
        public Task<ICollection<RoleDbo>> GetRoles();
        public Task<RoleDbo> GetRoleById(int id);
        public Task<RoleDbo> GetRoleByName(string name);
        public Task<RoleDbo> AddRole(RoleDbo role);
        public Task DeleteRole(RoleDbo role);
    }
}
