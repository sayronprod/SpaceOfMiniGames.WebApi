using Microsoft.Extensions.Configuration;

namespace SpaceOfMiniGames.WebApi.Data
{
    public class ApplicationSettings
    {
        private readonly IConfiguration configuration;
        private Credential db;

        public string DbConnectionString => configuration.GetConnectionString("DbConnection").Replace("@@uid", db.UserId).Replace("@@pass", db.Password);
        public string SecretKey => configuration.GetSection("SecretKey").Value;

        public int tokenLifeTime => Convert.ToInt32(configuration.GetSection("TokenLifeTime").Value);

        public ApplicationSettings(IConfiguration configuration)
        {
            this.configuration = configuration;

            db.UserId = "DevRobot";
            db.Password = "r*@Yy2eU3@Tj";
        }
    }

    struct Credential
    {
        public string UserId;
        public string Password;
    }
}