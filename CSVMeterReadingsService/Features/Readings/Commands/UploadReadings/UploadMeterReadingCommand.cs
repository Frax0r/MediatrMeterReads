using CSVMeterReadingsService.Features.Readings.Models;
using MediatR;

namespace CSVMeterReadingsService.Features.Readings.Commands.UploadReadings;

    public class UploadMeterReadingCommand(MeterReadingDto meterReadingDto) : IRequest<MeterReadingDto>
    {
        public MeterReadingDto MeterReadingDto { get; set; } = meterReadingDto;
    }

