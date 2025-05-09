using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSVMeterReadingsModels
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
            AccountId = accountId;
            MeterReadingDateTime = meterReadingDateTime;
            MeterReadValue = meterReadValue;
        }
    }
}
