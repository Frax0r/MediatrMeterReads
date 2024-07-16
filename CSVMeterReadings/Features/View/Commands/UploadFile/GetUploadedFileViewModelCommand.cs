using CSVMeterReadings.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CSVMeterReadingsService.Features.Readings.Commands.CreateReadings
{
    public class GetUploadedFileViewModelCommand : IRequest<ViewModel<CSVUploadVM>>
    {
        public IFormFile UploadedFile { get; set; }
    }
}
