using CsvHelper;
using System.Linq;
using MediatR;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CSVMeterReadingsService.Features.Readings.Models;
using FluentValidation.Results;
using System.Collections.Generic;

namespace CSVMeterReadingsService.Features.Readings.Commands.UploadFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, CSVUploadDto>
    {
        private readonly List<MeterReadingDto> _csvErrorList = [];

        public async Task<CSVUploadDto> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.GetCultureInfo("en-GB"))
            {
                 HasHeaderRecord = true,
                 IgnoreBlankLines = true,
                 ReadingExceptionOccurred = x => { AddCsvReadError(_csvErrorList, x); return false; }
            };

            using var reader = new StreamReader(request.File.OpenReadStream());
            using var csvReader = new CsvReader(reader, csvConfig);

            var meterReadings = (await Task.FromResult(csvReader.GetRecords<MeterReadingDto>().ToList())).Concat(_csvErrorList);

            return new CSVUploadDto { MeterReadings = meterReadings };
        }

        private static void AddCsvReadError(List<MeterReadingDto> csvErrorList, ReadingExceptionOccurredArgs ex)
        {
            csvErrorList.Add(new MeterReadingDto
            {
                ValidationResult = new ValidationResult
                {
                    Errors = new List<ValidationFailure>
                    {
                        {
                           new ValidationFailure
                           {
                             PropertyName = $"Record: {ex.Exception.Context.Parser.Row}",
                             ErrorMessage = $"Could not read record for row number: {ex.Exception.Context.Parser.Row}, accountId: {ex.Exception.Context.Parser.Record[0]}"  
                           }
                        }

                    }
                }
            });
        }
    }
}
