using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SpaceOfMiniGames.WebApi.Authentication;
using SpaceOfMiniGames.WebApi.Data;
using SpaceOfMiniGames.WebApi.Data.Repositorys;
using SpaceOfMiniGames.WebApi.Mapping;
using SpaceOfMiniGames.WebApi.Models.Interfaces;
using SpaceOfMiniGames.WebApi.Services;
using SpaceOfMiniGames.WebApi.Settings;
using System.Reflection;

namespace SpaceOfMiniGames.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStrings = new ApplicationSettings(Configuration);
            services.AddSingleton(connectionStrings);

            services.AddDataProtection()
                .UseCryptographicAlgorithms(
                    new AuthenticatedEncryptorConfiguration()
                    {
                        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256,

                    }
                );

            services.AddScoped<ISecureService, ISecureService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddAutoMapper(typeof(AppMappingProfile));

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(connectionStrings.DbConnectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddAuthentication(MyCustomTokenAuthOptions.DefaultScemeName)
                .AddScheme<MyCustomTokenAuthOptions, MyCustomTokenAuthHandler>(
                    MyCustomTokenAuthOptions.DefaultScemeName,
                    opts =>
                    {
                    }
            );

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ToDoWebApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.OperationFilter<AddAuthorizationHeaderOperationHeader>();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoWebApi V1");
                c.RoutePrefix = "api";
                c.DisplayRequestDuration();
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
