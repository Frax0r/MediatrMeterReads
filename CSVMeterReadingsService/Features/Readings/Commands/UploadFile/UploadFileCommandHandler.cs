using MediatR;
using CSVMeterReadingsService.Features.Readings.Models;
using System.Threading;
using System.Threading.Tasks;


namespace CSVMeterReadingsService.Features.Readings.Commands.UploadFile
{
    public class UploadFileCommandHandler() : IRequestHandler<UploadFileCommand, CSVUploadDto>
    {
        public Task<CSVUploadDto> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {

            return Task.FromResult(new CSVUploadDto());
        }
    }
}
