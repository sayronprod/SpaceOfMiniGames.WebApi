namespace SpaceOfMiniGames.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.ConfigureKestrel((serverOptions) =>
                        {
                        });
                        webBuilder.UseStartup<Startup>();
                    })
                    .Build()
                    .Run();
        }
    }
}