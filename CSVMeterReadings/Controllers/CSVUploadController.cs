using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CSVMeterReadings.ViewModel;
using MediatR;
using CSVMeterReadings.Features.View.Commands.UploadCSV;

namespace CSVMeterReadings.Controllers
{
    public class CSVUploadController : BaseController
    {      
        public CSVUploadController(IMediator mediator)
        {
            _mediator = (Mediator)mediator;
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
            ViewModel<CSVUploadVM> vm = await _mediator.Send(new GetUploadedCSVViewModelCommand { UploadedFile = file } ).ConfigureAwait(false);
           
            AddErrorsToModelState(vm.Core.ValidationResult);

            return View("Index", vm);

        }

    }
}
