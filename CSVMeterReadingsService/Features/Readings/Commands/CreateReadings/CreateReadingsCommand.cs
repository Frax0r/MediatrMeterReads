using CSVMeterReadingsService.Features.Readings.Models;
using MediatR;

namespace CSVMeterReadingsService.Features.Readings.Commands.CreateReadings
{
    public class CreateReadingsCommand : IRequest<MeterReadingDto>
    {
        public MeterReadingDto MeterReading { get; set; }
    }
}
