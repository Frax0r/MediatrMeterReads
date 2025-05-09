using System.Threading;
using System.Threading.Tasks;
using CSVMeterReadings.Presenter;
using CSVMeterReadings.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CSVMeterReadings.Features.View.Commands.UploadCSV
{
    public class RequestUploadedCSVViewModelCommandHandler(IPresenter<CSVUploadVM, IFormFile> presenter) : IRequestHandler<RequestUploadedCSVViewModelCommand, ViewModel<CSVUploadVM>>
    {
        public async Task<ViewModel<CSVUploadVM>> Handle(RequestUploadedCSVViewModelCommand request, CancellationToken cancellationToken)
        {
                return await presenter.GetViewModelAsync(request.UploadedFile);
        }
    }
}
