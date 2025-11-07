using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using MediatR;
using CSVMeterReadings.Features.View.Commands.UploadCSV;
using CSVMeterReadings.Features.View.Commands.UnitOfWork;

namespace CSVMeterReadings.Controllers
{
    public class CSVUploadController(IMediator mediator) : BaseController()
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
            var vm = await mediator.Send(new RequestUploadedCSVViewModelCommand { UploadedFile = file } ).ConfigureAwait(false);

            AddErrorsToModelState(vm.Model.ValidationResult);

            await mediator.Send(new UnitOfWorkCommand()).ConfigureAwait(false);

            return View("Index", vm);

        }

    }
}
