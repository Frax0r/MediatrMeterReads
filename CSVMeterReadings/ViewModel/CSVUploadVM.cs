using System.Collections.Generic;
using CSVMeterReadingsService.Features.Readings.Models;

namespace CSVMeterReadings.ViewModel
{
    public class CSVUploadVM : ValidationDto
    {
        public IEnumerable<MeterReadingVM> MeterReadings { get; set; }

        public uint SavedCount { get; set; }

        public uint NotSavedCount { get; set; }

    }
}
