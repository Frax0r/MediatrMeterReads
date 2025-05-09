using System.Collections.Generic;
using System.Linq;

namespace CSVMeterReadingsService.Features.Readings.Models
{
    public class CSVUploadDto : ValidationDto
    {
        public IEnumerable<MeterReadingDto> MeterReadings = [];

        public uint SavedCount => (uint)MeterReadings.Count(x => x.ValidationResult.IsValid);

        public uint NotSavedCount => (uint)MeterReadings.Count() - SavedCount; 

    }
}
