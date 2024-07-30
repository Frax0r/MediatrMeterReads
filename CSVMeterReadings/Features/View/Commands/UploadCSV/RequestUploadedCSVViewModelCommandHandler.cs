using System.Threading;
using System.Threading.Tasks;
using CSVMeterReadings.Presenter;
using CSVMeterReadings.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CSVMeterReadings.Features.View.Commands.UploadCSV
{
    public class RequestUploadedCSVViewModelCommandHandler : IRequestHandler<RequestUploadedCSVViewModelCommand, ViewModel<CSVUploadVM>>
    {
        private IPresenter<CSVUploadVM, IFormFile> _presenter;

        public RequestUploadedCSVViewModelCommandHandler(IPresenter<CSVUploadVM, IFormFile> presenter)
        {
            _presenter = presenter;
        }

        public async Task<ViewModel<CSVUploadVM>> Handle(RequestUploadedCSVViewModelCommand request, CancellationToken cancellationToken)
        {
                return await _presenter.GetViewModelAsync(request.UploadedFile);
        }
    }
}
