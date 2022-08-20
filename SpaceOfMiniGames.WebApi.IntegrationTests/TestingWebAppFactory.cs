using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpaceOfMiniGames.WebApi.Data;

namespace SpaceOfMiniGames.WebApi.IntegrationTests
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<ApplicationContext>));
                if (descriptor != null)
                    services.Remove(descriptor);
                services.AddDbContext<ApplicationContext>(options =>
                {
                    options.UseLazyLoadingProxies();
                    options.UseInMemoryDatabase("InMemoryApplicationTest");
                });
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>())
                {
                    try
                    {
                        if (appContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                            appContext.Database.Migrate();
                        appContext.Database.EnsureCreated();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            });
        }
    }
}
