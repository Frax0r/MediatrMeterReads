using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CSVMeterReadings.ViewModel;
using MediatR;
using CSVMeterReadings.Features.View.Commands.UploadCSV;
using CSVMeterReadings.Features.View.Commands.UnitOfWork;

namespace CSVMeterReadings.Controllers
{
    public class CSVUploadController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<ActionResult> MeterReadingUploads(IFormFile file)
        {
            ViewModel<CSVUploadVM> vm = await _mediator.Send(new RequestUploadedCSVViewModelCommand { UploadedFile = file } ).ConfigureAwait(false);

            AddErrorsToModelState(vm.Model.ValidationResult);

            await _mediator.Send(new UnitOfWorkCommand()).ConfigureAwait(false);

            return View("Index", vm);

        }

    }
}
