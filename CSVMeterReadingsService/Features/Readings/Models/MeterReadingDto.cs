using System;

namespace CSVMeterReadingsService.Features.Readings.Models
{
    public class MeterReadingDto : ValidationDto
    {
        public ulong AccountId { get; set; }

        public DateTime MeterReadingDateTime { get; set; }

        public string MeterReadValue { get; set; }

    }
}
