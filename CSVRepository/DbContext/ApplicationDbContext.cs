using CSVMeterReadings.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().HasKey(a => new { a.AccountId });
            modelBuilder.Entity<Account>().ToTable("Account");

            modelBuilder.Entity<MeterReading>().HasKey(m => new { m.AccountId, m.MeterReadingDateTime });

            modelBuilder.Entity<MeterReading>().ToTable("MeterReading");

        }
    }

}