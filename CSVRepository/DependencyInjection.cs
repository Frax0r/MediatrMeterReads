using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {            
            services.AddScoped(typeof(IRepository<>), typeof(MeterReadingDataRepository<>));
            return services;
        }
    }
}
