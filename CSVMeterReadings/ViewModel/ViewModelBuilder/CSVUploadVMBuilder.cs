using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CSVMeterReadingsService.Features.Readings.Commands.CreateReadings;
using CSVMeterReadingsService.Features.Readings.Commands.UploadFile;
using CSVMeterReadingsService.Features.Readings.Models;
using MediatR;
using System.Linq;

namespace CSVMeterReadings.ViewModel.ViewModelBuilder
{
    internal class CSVUploadVMBuilder(IMediator mediator, IMapper mapper) : ViewModelBuilderBase<CSVUploadVM, IFormFile>
    {
        private readonly Mediator _mediator = (Mediator)mediator;

        public override async Task BuildViewModelAsync()
        {
            CSVUploadDto fileUpload = await _mediator.Send(new UploadFileCommand { File = _InputObject }).ConfigureAwait(false);

            foreach (MeterReadingDto meterReading in fileUpload.MeterReadings.Where(mr => mr.ValidationResult.IsValid))
            {
                    meterReading.ValidationResult = (await _mediator.Send(new CreateReadingsCommand { MeterReading = meterReading }).ConfigureAwait(false)).ValidationResult;
            }

            _ViewModel.Model = mapper.Map<CSVUploadDto, CSVUploadVM>(fileUpload);

        }
    }
}