using LoginAPI.Api;
using LoginAPI.Dtos;
using LoginAPI.Persistence;
using LoginAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApi(configuration)
                .AddMapper()
                .AddPersistence(configuration)
                .AddServices();
            return services;
        }
    }
}