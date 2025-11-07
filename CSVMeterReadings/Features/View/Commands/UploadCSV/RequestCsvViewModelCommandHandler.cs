using System.Threading;
using System.Threading.Tasks;
using CSVMeterReadingsAPI.Presenter;
using CSVMeterReadingsAPI.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CSVMeterReadingsAPI.Features.View.Commands.UploadCSV
{
    public class RequestCsvViewModelCommandHandler(IPresenter<CsvUploadVM, IFormFile> presenter) : IRequestHandler<RequestCsvViewModelCommand, ViewModel<CsvUploadVM>>
    {
        public async Task<ViewModel<CsvUploadVM>> Handle(RequestCsvViewModelCommand request, CancellationToken cancellationToken)
        {
                return await presenter.GetViewModelAsync(request.UploadedFile);
        }
    }
}
