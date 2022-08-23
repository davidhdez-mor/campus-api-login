using Microsoft.Extensions.DependencyInjection;

namespace LoginAPI.Dtos
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DependencyContainer));
            return services;
        }
    }
}