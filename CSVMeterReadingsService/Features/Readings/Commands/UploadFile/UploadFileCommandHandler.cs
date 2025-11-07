using MediatR;
using CSVMeterReadingsService.Features.Readings.Models;
using CSVMeterReadingsService.Features.Readings.Commands.ParseMeterReadings;
using System.Threading;
using System.Threading.Tasks;

namespace CSVMeterReadingsService.Features.Readings.Commands.UploadFile
{
    public class UploadFileCommandHandler(IMediator mediator) : IRequestHandler<UploadFileCommand, CSVUploadDto>
    {
        private readonly IMediator _mediator = mediator;

        public async Task<CSVUploadDto> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var meterReadings = await _mediator.Send(new ParseCsvMeterReadingsCommand(request.File), cancellationToken);

            return new CSVUploadDto
            {
                MeterReadings = meterReadings
            };
        }
    }
}
