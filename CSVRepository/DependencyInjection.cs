using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.DbContext;
using Repository.Interfaces;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<IApplicationDbContext>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
