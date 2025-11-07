using CSVMeterReadingsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository.DbContext
{
    public interface IApplicationDbContext { }
    public class ApplicationDbContext(IConfiguration configuration) : Microsoft.EntityFrameworkCore.DbContext, IApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = bool.TryParse(configuration["UseInMemoryDB"], out bool useInMemory);

            if (useInMemory) 
            {
                optionsBuilder.UseInMemoryDatabase("TestDB");
            }
            else 
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {     
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().HasKey(a => new { a.AccountId });
            modelBuilder.Entity<Account>().ToTable("Account");

            modelBuilder.Entity<MeterReading>().HasKey(m => new { m.AccountId, m.MeterReadingDateTime });
            modelBuilder.Entity<MeterReading>().ToTable("MeterReading");

            SeedAccounts(modelBuilder);
        }
        private static void SeedAccounts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                  new Account(2344, "Tommy", "Test"),
                  new Account(2233, "Barry", "Test"),
                  new Account(8766, "Sally", "Test"),
                  new Account(2345, "Jerry", "Test"),
                  new Account(2346, "Ollie", "Test"),
                  new Account(2347, "Tara", "Test"),
                  new Account(2348, "Tammy", "Test"),
                  new Account(2349, "Simon", "Test"),
                  new Account(2350, "Colin", "Test"),
                  new Account(2351, "Gladys", "Test"),
                  new Account(2352, "Greg", "Test"),
                  new Account(2353, "Tony", "Test"),
                  new Account(2355, "Arthur", "Test"),
                  new Account(2356, "Craig", "Test"),
                  new Account(6776, "Laura", "Test"),
                  new Account(4534, "JOSH", "TEST"),
                  new Account(1234, "Freya", "Test"),
                  new Account(1239, "Noddy", "Test"),
                  new Account(1240, "Archie", "Test"),
                  new Account(1241, "Lara", "Test"),
                  new Account(1242, "Tim", "Test"),
                  new Account(1243, "Graham", "Test"),
                  new Account(1244, "Tony", "Test"),
                  new Account(1245, "Neville", "Test"),
                  new Account(1246, "Jo", "Test"),
                  new Account(1247, "Jim", "Test"),
                  new Account(1248, "Pam", "Test") 
             );
            
        }

    }
}