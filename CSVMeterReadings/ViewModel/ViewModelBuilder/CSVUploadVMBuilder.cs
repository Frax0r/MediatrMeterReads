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
        public override async Task BuildViewModelAsync()
        {
            var csvUploadResult = await mediator.Send(new UploadFileCommand { File = _InputObject }).ConfigureAwait(false);

            foreach (MeterReadingDto meterReading in csvUploadResult.MeterReadings.Where(mr => mr.ValidationResult.IsValid))
            {
                    meterReading.ValidationResult = (await mediator.Send(new CreateReadingsCommand { MeterReading = meterReading }).ConfigureAwait(false)).ValidationResult;
            }

            _ViewModel.Model = mapper.Map<CSVUploadDto, CSVUploadVM>(csvUploadResult);

        }
    }
}