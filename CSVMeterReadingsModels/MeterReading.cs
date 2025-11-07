using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSVMeterReadingsModels
{
    public class MeterReading(ulong accountId, DateTime meterReadingDateTime, uint meterReadValue)
    {
        [Column("AccountId", TypeName = "bigint")]
        public ulong AccountId { get; set; } = accountId;
        public DateTime MeterReadingDateTime { get; set; } = meterReadingDateTime;

        [Column("MeterReadValue", TypeName = "int")]
        public uint MeterReadValue { get; set; } = meterReadValue;
    }
}
