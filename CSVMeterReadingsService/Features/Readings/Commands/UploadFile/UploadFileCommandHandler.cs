using CsvHelper;
using System.Linq;
using MediatR;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CSVMeterReadingsService.Features.Readings.Models;

namespace CSVMeterReadingsService.Features.Readings.Commands.UploadFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, CSVUploadDto>
    {
        public async Task<CSVUploadDto> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.GetCultureInfo("en-GB"))
            {
                HasHeaderRecord = true,
                IgnoreBlankLines = true
            };

            using var reader = new StreamReader(request.File.OpenReadStream());
            using var csvReader = new CsvReader(reader, csvConfig);

            return new CSVUploadDto { MeterReadings = await Task.FromResult(csvReader.GetRecords<MeterReadingDto>().ToList()) };
        }
    }
}
