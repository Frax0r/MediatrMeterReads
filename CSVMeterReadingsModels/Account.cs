using CSVMeterReadings.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSVMeterReadings.Models
{
    // Pocos, with ef tags for code first db creation etc
    public class Account : IIdentity
    {
        [Column("AccountId", TypeName = "bigint"), Key]
        public ulong AccountId { get; set; }

        [Column("FirstName", TypeName = "varchar(20)"), Required]
        public string FirstName { get; set; }

        [Column("LastName", TypeName = "varchar(20)"), Required]
        public string LastName { get; set; }

        [ForeignKey("AccountId")]
        public IEnumerable<MeterReading> MeterReadings { get; set; }

        public Account(ulong AccountId, string FirstName, string LastName)
        {
          this.AccountId = AccountId;
          this.FirstName = FirstName;
          this.LastName = LastName;
        }
    }
}
