using CSVMeterReadingsService.Features.Readings.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CSVMeterReadingsService.Features.Readings.Commands.UploadFile
{
    public class UploadFileCommand(IFormFile file) : IRequest<CSVUploadDto>
    {
        public IFormFile File { get; set; } = file;
    }
}
