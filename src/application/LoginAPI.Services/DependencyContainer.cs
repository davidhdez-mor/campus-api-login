using LoginAPI.Services.Abstractions;
using LoginAPI.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LoginAPI.Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtService, JwtService>();
            return services;
        }
    }
}