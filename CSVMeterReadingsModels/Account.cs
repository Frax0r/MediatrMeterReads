using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSVMeterReadingsModels
{
    public class Account(ulong AccountId, string FirstName, string LastName)
    {
        [Column("AccountId", TypeName = "bigint"), Key]
        public ulong AccountId { get; set; } = AccountId;

        [Column("FirstName", TypeName = "varchar(20)"), Required]
        public string FirstName { get; set; } = FirstName;

        [Column("LastName", TypeName = "varchar(20)"), Required]
        public string LastName { get; set; } = LastName;

        [ForeignKey("AccountId")]
        public IEnumerable<MeterReading> MeterReadings { get; set; }
    }
}
