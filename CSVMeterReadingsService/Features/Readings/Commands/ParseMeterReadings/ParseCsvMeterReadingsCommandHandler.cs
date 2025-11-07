using CsvHelper;
using CsvHelper.Configuration;
using CSVMeterReadingsService.Features.Readings.Models;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSVMeterReadingsService.Features.Readings.Commands.ParseMeterReadings
{
    public class ParseCsvMeterReadingsCommandHandler : IRequestHandler<ParseCsvMeterReadingsCommand, IEnumerable<MeterReadingDto>>
    {
        public Task<IEnumerable<MeterReadingDto>> Handle(ParseCsvMeterReadingsCommand request, CancellationToken cancellationToken)
        {
            var csvErrorList = new List<MeterReadingDto>();

            var csvConfig = new CsvConfiguration(CultureInfo.GetCultureInfo("en-GB"))
            {
                HasHeaderRecord = true,
                IgnoreBlankLines = true,
                ReadingExceptionOccurred = x => { AddCsvReadError(csvErrorList, x); return false; }
            };

            using var reader = new StreamReader(request.File.OpenReadStream());
            using var csvReader = new CsvReader(reader, csvConfig);

            var meterReadings = csvReader.GetRecords<MeterReadingDto>().Concat(csvErrorList).ToList();

            return Task.FromResult((IEnumerable<MeterReadingDto>)meterReadings);
        }

        private static void AddCsvReadError(List<MeterReadingDto> csvErrorList, ReadingExceptionOccurredArgs ex)
        {
            csvErrorList.Add(new MeterReadingDto
            {
                ValidationResult = new ValidationResult
                {
                    Errors =
                    [
                        new ValidationFailure
                        {
                            PropertyName = $"Record: {ex.Exception.Context.Parser.Row}",
                            ErrorMessage = $"Could not parse record for row number: {ex.Exception.Context.Parser.Row}, accountId: {ex.Exception.Context.Parser.Record[0]}"
                        }
                    ]
                }
            });
        }
    }
}