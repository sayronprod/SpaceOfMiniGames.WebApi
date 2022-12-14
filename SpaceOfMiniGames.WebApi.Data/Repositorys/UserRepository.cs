using Microsoft.EntityFrameworkCore;
using SpaceOfMiniGames.WebApi.Models.Interfaces;
using SpaceOfMiniGames.WebApi.Models.ModelsDbo;

namespace SpaceOfMiniGames.WebApi.Data.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext context;

        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<UserDbo>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<UserDbo> GetUserById(int id)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserDbo> GetUserByLogin(string login)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<UserDbo> Add(UserDbo newUser)
        {
            var createdUser = await context.Users.AddAsync(newUser);

            await context.SaveChangesAsync();

            return createdUser.Entity;
        }

        public async Task<UserDbo> Update(UserDbo user)
        {
            var updatedUser = context.Users.Update(user);
            await context.SaveChangesAsync();
            return updatedUser.Entity;
        }

        public async Task DeleteUser(UserDbo user)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
