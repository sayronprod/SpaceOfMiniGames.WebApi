using SpaceOfMiniGames.WebApi.Models.Interfaces;
using SpaceOfMiniGames.WebApi.Models.ModelsDbo;

namespace SpaceOfMiniGames.WebApi.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public async Task<ICollection<string>> GetRoles()
        {
            var roles = await roleRepository.GetRoles();
            return roles.Select(x => x.RoleName).ToList();
        }

        public async Task AddRole(string roleName)
        {
            var existRole = await roleRepository.GetRoleByName(roleName);
            if (existRole is null)
            {
                var newRole = new RoleDbo
                {
                    RoleName = roleName
                };
                await roleRepository.AddRole(newRole);
            }
        }

        public async Task DeleteRole(string roleName)
        {
            var existRole = await roleRepository.GetRoleByName(roleName);
            if (existRole is not null)
            {
                await roleRepository.DeleteRole(existRole);
            }
        }

        public async Task<bool> IsExistsRole(string roleName)
        {
            var roles = await GetRoles();
            return roles.Contains(roleName);
        }
    }
}
