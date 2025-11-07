using System.Collections.Generic;

namespace CSVMeterReadingsAPI.ViewModel
{
    public class CsvUploadVM : ValidationDtoVM
    {
        public IEnumerable<MeterReadingVM> MeterReadings { get; set; }

        public uint SavedCount { get; set; }

        public uint NotSavedCount { get; set; }

    }
}
