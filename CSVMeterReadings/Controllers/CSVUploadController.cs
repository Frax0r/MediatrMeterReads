using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CSVMeterReadings.ViewModel;
using CSVMeterReadings.ViewModel.ViewModelBuilder;
using MediatR;

namespace CSVMeterReadings.Controllers
{
    public class CSVUploadController : BaseController
    {
        public CSVUploadController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = (Mediator)mediator;
            _presenter = new Presenter.Presenter();
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
            ViewModel<FileUploadVM> vm = await _presenter.GetViewModel(new CSVUploadVMBuilder(_mediator, _mapper), file);

            AddErrorToModelStateErrors(vm.Core.ValidationResult);

            return View("Index", vm);

        }

    }
}
