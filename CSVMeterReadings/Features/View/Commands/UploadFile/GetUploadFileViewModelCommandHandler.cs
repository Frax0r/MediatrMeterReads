using System.Threading;
using System.Threading.Tasks;
using CSVMeterReadings.Presenter;
using CSVMeterReadings.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CSVMeterReadingsService.Features.Readings.Commands.CreateReadings
{
    public class GetUploadFileViewModelCommandHandler : IRequestHandler<GetUploadedFileViewModelCommand, ViewModel<CSVUploadVM>>
    {
        private IPresenter<CSVUploadVM, IFormFile> _presenter;

        public GetUploadFileViewModelCommandHandler(IPresenter<CSVUploadVM, IFormFile> presenter)
        {
            _presenter = presenter;
        }

        public async Task<ViewModel<CSVUploadVM>> Handle(GetUploadedFileViewModelCommand request, CancellationToken cancellationToken)
        {
                return await _presenter.GetViewModelAsync(request.UploadedFile);
        }
    }
}
