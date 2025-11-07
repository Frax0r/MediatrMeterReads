using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using MediatR;
using CSVMeterReadingsAPI.Features.View.Commands.UploadCSV;
using CSVMeterReadingsAPI.Features.View.Commands.UnitOfWork;

namespace CSVMeterReadingsAPI.Controllers
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
            var vm = await mediator.Send(new RequestCsvViewModelCommand { UploadedFile = file } ).ConfigureAwait(false);

            AddErrorsToModelState(vm.Model.ValidationResult);

            await mediator.Send(new UnitOfWorkCommand()).ConfigureAwait(false);

            return View("Index", vm);

        }

    }
}
