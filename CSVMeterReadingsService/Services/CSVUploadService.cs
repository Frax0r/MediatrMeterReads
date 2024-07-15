using Repository;
using CSVMeterReadings.Models;
using Repository.DbPopulationShim;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Threading;

// Not applcation code, this is used to seed accounts db as required!
namespace CSVMeterReadingsService.Services
{
    public class CSVUploadService
    {
        public async static Task SeedAccountsAsync(IConfiguration configuration, CancellationToken cancellationToken)
        {
            var repo = new MeterReadingDataRepository<Account>(configuration);
            await InitialiseDb.SeedAsync(repo, cancellationToken);
        }

    }
}
