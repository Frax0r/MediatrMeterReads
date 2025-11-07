using AutoMapper;
using CSVMeterReadingsService.Features.Readings.Commands.ParseMeterReadings;
using CSVMeterReadingsService.Features.Readings.Commands.UploadFile;
using CSVMeterReadingsService.Features.Readings.Commands.UploadReadings;
using CSVMeterReadingsService.Features.Readings.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace CSVMeterReadings.ViewModel.ViewModelBuilder
{
    internal class CSVUploadVMBuilder(IMediator mediator, IMapper mapper) : ViewModelBuilderBase<CSVUploadVM, IFormFile>
    {
        public override async Task BuildViewModelAsync()
        {
            var csvUploadDto = await mediator.Send(new UploadFileCommand(_InputObject)).ConfigureAwait(false);

            if (csvUploadDto.ValidationResult.IsValid)
            {
                var meterReadings = await mediator.Send(new ParseCsvMeterReadingsCommand(_InputObject));

                foreach (var meterReading in meterReadings.Where(mr => mr.ValidationResult.IsValid))
                {
                    meterReading.ValidationResult = (await mediator.Send(new UploadMeterReadingCommand(meterReading)).ConfigureAwait(false)).ValidationResult;
                }

                csvUploadDto.MeterReadings = meterReadings;

            }

            _ViewModel.Model = mapper.Map<CSVUploadDto, CSVUploadVM>(csvUploadDto);

        }
    }
}