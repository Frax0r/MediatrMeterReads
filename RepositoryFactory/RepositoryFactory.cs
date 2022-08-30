using Repository;
using RepositoryFactory.Interfaces;
using Microsoft.Extensions.Configuration;

namespace RepositoryFactory
{
    public static class RepositoryFactory
    {           
        public static IMeterReadingDataRepository GetConductMIDataRepository(IConfiguration configuration)
        {
            return new MeterReadingDataRepository(configuration);
        }
    }
}
