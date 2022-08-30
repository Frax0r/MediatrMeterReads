using Repository;
using CSVMeterReadings.Models;
using Repository.DbPopulationShim;
using Microsoft.Extensions.Configuration;

// Not applcation code, this is used to seed accounts db as required!
namespace CSVMeterReadings.Service
{
    public class CSVUploadService
    {

        private readonly IConfiguration _configuration;

        public CSVUploadService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public static void SeedAccounts(IConfiguration configuration)
        {
            var repo = new MeterReadingDataRepository<Account>(configuration);
            InitialiseDb.Seed(repo);
        }

    }
}
