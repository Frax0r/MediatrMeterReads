using CSVMeterReadings.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.DbPopulationShim
{
    // NOT Solution code!, Just a quick and dirty database pre Population shimm with ef6
    // Will create the accounts data
    public static class InitialiseDb
    {
        public static async Task SeedAsync(MeterReadingDataRepository<Account> rpos, CancellationToken cancellationToken)
        {
            try
            {              
                await rpos.CreateDbAsync(cancellationToken);
                if (await rpos.GetByID(2344, cancellationToken) == null){await rpos.Insert(new Account(2344,"Tommy",   "Test")); }
                if (await rpos.GetByID(2233, cancellationToken) == null){await rpos.Insert(new Account(2233,"Barry",   "Test")); }
                if (await rpos.GetByID(8766, cancellationToken) == null){await rpos.Insert(new Account(8766,"Sally",   "Test")); }
                if (await rpos.GetByID(2345, cancellationToken) == null){await rpos.Insert(new Account(2345,"Jerry",   "Test")); }
                if (await rpos.GetByID(2346, cancellationToken) == null){await rpos.Insert(new Account(2346,"Ollie",   "Test")); }
                if (await rpos.GetByID(2347, cancellationToken) == null){await rpos.Insert(new Account(2347,"Tara" ,   "Test")); }
                if (await rpos.GetByID(2348, cancellationToken) == null){await rpos.Insert(new Account(2348,"Tammy",   "Test")); }
                if (await rpos.GetByID(2349, cancellationToken) == null){await rpos.Insert(new Account(2349,"Simon",   "Test")); }
                if (await rpos.GetByID(2350, cancellationToken) == null){await rpos.Insert(new Account(2350,"Colin",   "Test")); }
                if (await rpos.GetByID(2351, cancellationToken) == null){await rpos.Insert(new Account(2351,"Gladys",  "Test")); }
                if (await rpos.GetByID(2352, cancellationToken) == null){await rpos.Insert(new Account(2352,"Greg",    "Test")); }
                if (await rpos.GetByID(2353, cancellationToken) == null){await rpos.Insert(new Account(2353,"Tony",    "Test")); }
                if (await rpos.GetByID(2355, cancellationToken) == null){await rpos.Insert(new Account(2355,"Arthur",  "Test")); }
                if (await rpos.GetByID(2356, cancellationToken) == null){await rpos.Insert(new Account(2356,"Craig",   "Test")); }
                if (await rpos.GetByID(6776, cancellationToken) == null){await rpos.Insert(new Account(6776,"Laura",   "Test")); }
                if (await rpos.GetByID(4534, cancellationToken) == null){await rpos.Insert(new Account(4534,"JOSH",    "TEST")); }
                if (await rpos.GetByID(1234, cancellationToken) == null){await rpos.Insert(new Account(1234,"Freya",   "Test")); }
                if (await rpos.GetByID(1239, cancellationToken) == null){await rpos.Insert(new Account(1239,"Noddy",   "Test")); }
                if (await rpos.GetByID(1240, cancellationToken) == null){await rpos.Insert(new Account(1240,"Archie",  "Test")); }
                if (await rpos.GetByID(1241, cancellationToken) == null){await rpos.Insert(new Account(1241,"Lara",    "Test")); }
                if (await rpos.GetByID(1242, cancellationToken) == null){await rpos.Insert(new Account(1242,"Tim",     "Test")); }
                if (await rpos.GetByID(1243, cancellationToken) == null){await rpos.Insert(new Account(1243,"Graham",  "Test")); }
                if (await rpos.GetByID(1244, cancellationToken) == null){await rpos.Insert(new Account(1244,"Tony",    "Test")); }
                if (await rpos.GetByID(1245, cancellationToken) == null){await rpos.Insert(new Account(1245,"Neville", "Test")); }
                if (await rpos.GetByID(1246, cancellationToken) == null){await rpos.Insert(new Account(1246,"Jo",      "Test")); }
                if (await rpos.GetByID(1247, cancellationToken) == null){await rpos.Insert(new Account(1247,"Jim",     "Test")); }
                if (await rpos.GetByID(1248, cancellationToken) == null){await rpos.Insert(new Account(1248,"Pam",     "Test")); } 

            }
            catch 
            {
            };
     
        }

    }

}