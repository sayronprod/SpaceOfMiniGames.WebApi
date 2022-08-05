using Microsoft.EntityFrameworkCore;
using SpaceOfMiniGames.WebApi.Models.ModelsDbo;

namespace SpaceOfMiniGames.WebApi.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserDbo> Users { get; set; }
        public DbSet<RoleDbo> Roles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
