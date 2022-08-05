namespace SpaceOfMiniGames.WebApi.Models.Interfaces
{
    public interface IRoleService
    {
        public Task<ICollection<string>> GetRoles();
        public Task AddRole(string roleName);
        public Task DeleteRole(string roleName);
        public Task<bool> IsExistsRole(string roleName);
    }
}
