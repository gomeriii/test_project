using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SecondService.Extensions;
using SecondService.Infrastructure.Persistence;

namespace SecondService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .MigrateDatabase<SecondServiceContext>((context, services) =>
                {
                    var logger = services.GetService<ILogger<SecondServiceContextSeed>>();
                    SecondServiceContextSeed
                        .SeedAsync(context, logger)
                        .Wait();
                })
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
