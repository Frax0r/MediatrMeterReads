using CSVMeterReadings.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRepository<Account>, MeterReadingDataRepository<Account>>();
            services.AddTransient<IRepository<MeterReading>, MeterReadingDataRepository <MeterReading>>();
            return services;
        }
    }
}
