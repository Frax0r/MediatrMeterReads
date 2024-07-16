using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CSVMeterReadings.ViewModel;
using MediatR;
using CSVMeterReadings.Presenter;
using CSVMeterReadingsService.Features.Readings.Commands.CreateReadings;

namespace CSVMeterReadings.Controllers
{
    public class CSVUploadController : BaseController
    {
       // private IPresenter<CSVUploadVM, IFormFile> _presenter;
        public CSVUploadController(IMediator mediator)//, IPresenter<CSVUploadVM, IFormFile> presenter)
        {
            _mediator = (Mediator)mediator;
          //  _presenter = presenter;
        }

        [HttpGet]
        public ActionResult Index()
        {   
            return View();
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<ActionResult> MeterReadingUploads(IFormFile file)
        {
            ViewModel<CSVUploadVM> vm = await _mediator.Send(new GetUploadedFileViewModelCommand { UploadedFile = file } ); //await _presenter.GetViewModel(file);

            AddErrorsToModelState(vm.Core.ValidationResult);

            return View("Index", vm);

        }

    }
}
