using CSVMeterReadings.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CSVMeterReadings.Features.View.Commands.UploadCSV
{
    public class GetUploadedCSVViewModelCommand : IRequest<ViewModel<CSVUploadVM>>
    {
        public IFormFile UploadedFile { get; set; }
    }
}
