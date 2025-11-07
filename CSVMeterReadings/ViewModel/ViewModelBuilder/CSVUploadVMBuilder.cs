using AutoMapper;
using CSVMeterReadingsService.Features.Readings.Commands.ParseMeterReadings;
using CSVMeterReadingsService.Features.Readings.Commands.UploadFile;
using CSVMeterReadingsService.Features.Readings.Commands.UploadReadings;
using CSVMeterReadingsService.Features.Readings.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace CSVMeterReadingsAPI.ViewModel.ViewModelBuilder
{
    internal class CSVUploadVMBuilder(IMediator mediator, IMapper mapper) : ViewModelBuilderBase<CsvUploadVM, IFormFile>
    {
        public override async Task BuildViewModelAsync()
        {
            var csvUploadDto = await mediator.Send(new UploadFileCommand(_InputObject)).ConfigureAwait(false);

            if (csvUploadDto.ValidationResult.IsValid)
            {
                var meterReadings = await mediator.Send(new ParseCsvMeterReadingsCommand(_InputObject));

                var parsedReadings = meterReadings.Where(mr => mr.ValidationResult.IsValid).ToList();

                var uploadTasks = parsedReadings
                    .Select(meterReading => mediator.Send(new UploadMeterReadingCommand(meterReading)));

                var uploadResults = await Task.WhenAll(uploadTasks).ConfigureAwait(false);
  
                for (int i = 0; i < parsedReadings.Count; i++)
                {
                    parsedReadings[i].ValidationResult = uploadResults[i].ValidationResult;
                }

                csvUploadDto.MeterReadings = meterReadings;
            }

            _ViewModel.Model = mapper.Map<CSVUploadDto, CsvUploadVM>(csvUploadDto);

        }
    }
}