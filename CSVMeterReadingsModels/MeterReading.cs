using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSVMeterReadings.Models
{
    // Pocos, with ef tags for code first db creation etc
    public class MeterReading
    {
        [Column("AccountId", TypeName = "bigint")]
        public ulong AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }

        [Column("MeterReadValue", TypeName = "int")]
        public uint MeterReadValue { get; set; }

        public MeterReading(ulong accountId, DateTime meterReadingDateTime, uint meterReadValue) 
        {
            this.AccountId = accountId;
            this.MeterReadingDateTime = meterReadingDateTime;
            this.MeterReadValue = meterReadValue;
        }
    }
}
