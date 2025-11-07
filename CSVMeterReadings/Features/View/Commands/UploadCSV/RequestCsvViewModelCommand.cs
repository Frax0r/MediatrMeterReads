using CSVMeterReadingsAPI.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CSVMeterReadingsAPI.Features.View.Commands.UploadCSV
{
    public class RequestCsvViewModelCommand : IRequest<ViewModel<CsvUploadVM>>
    {
        public IFormFile UploadedFile { get; set; }
    }
}
