using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecondService.Application.Contracts.Persistence;
using SecondService.Infrastructure.Repositories;

namespace SecondService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));                        
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
