using CSVMeterReadingsService.Features.Readings.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CSVMeterReadingsService.Features.Readings.Commands.UploadFile
{
    public class UploadFileCommand : IRequest<FileUploadDto>
    {
        public IFormFile File { get; set; }
    }
}
