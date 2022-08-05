using Microsoft.EntityFrameworkCore;
using SpaceOfMiniGames.WebApi.Models.Enums;
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

            DataSeed(modelBuilder);

            modelBuilder
                .Entity<UserDbo>()
                .HasMany(c => c.UserRoles)
                .WithMany(s => s.Users)
                .UsingEntity<RoleRelationship>(
                   j => j
                    .HasOne(pt => pt.Role)
                    .WithMany(t => t.RoleRelationships)
                    .HasForeignKey(pt => pt.RoleId),
                j => j
                    .HasOne(pt => pt.User)
                    .WithMany(p => p.RoleRelationships)
                    .HasForeignKey(pt => pt.UserId),
                j =>
                {
                    j.HasKey(t => new { t.UserId, t.RoleId });
                    j.ToTable("UserRoles");
                });
        }

        private void DataSeed(ModelBuilder modelBuilder)
        {
            string[] roles = Enum.GetNames(typeof(Roles));

            List<RoleDbo> roleList = new List<RoleDbo>();

            for (int i = 0; i < roles.Length; i++)
            {
                roleList.Add(new RoleDbo
                {
                    Id = i + 1,
                    RoleName = roles[i]
                });
            }

            modelBuilder.Entity<RoleDbo>().HasData(roleList);

            List<RoleRelationship> roleRelationships = new List<RoleRelationship>();

            foreach (var item in roleList)
            {
                roleRelationships.Add(new RoleRelationship
                {
                    RoleId = item.Id,
                    UserId = 1
                });
            }

            modelBuilder.Entity<RoleRelationship>().HasData(roleRelationships);

            modelBuilder.Entity<UserDbo>().HasData(
                new UserDbo
                {
                    Id = 1,
                    Login = "sirion",
                    PasswordHash = "81DC9BDB52D04DC20036DBD8313ED055",
                    RegistrationDate = DateTime.Now
                });
        }
    }
}
