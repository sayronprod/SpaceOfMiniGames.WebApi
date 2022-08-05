namespace SpaceOfMiniGames.WebApi.Models.Interfaces
{
    public interface IUserService
    {
        public Task<ICollection<User>> GetUsers();
        public Task<User> GetUserById(int id);
        public Task<User> GetUserByLogin(string login);
        public Task<User> CreateUser(string login, string password);
        public Task<bool> UpdateUserPassword(string login, string oldPassword, string newPassword);
        public Task DeleteUserById(int id);
        public Task DeleteUserByLogin(string login);
        public Task<bool> AuthorizeUser(string login, string password);
        public Task<(bool, string)> GrantRoleToUserById(int id, string roleName);
        public Task<(bool, string)> GrantRoleToUserByLogin(string login, string roleName);
        public Task<bool> DeleteRoleInUserById(int id, string roleName);
        public Task<bool> DeleteRoleInUserByLogin(string login, string roleName);
    }
}
