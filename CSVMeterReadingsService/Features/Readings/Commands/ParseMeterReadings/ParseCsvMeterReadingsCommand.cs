using MediatR;
using Microsoft.AspNetCore.Http;
using CSVMeterReadingsService.Features.Readings.Models;
using System.Collections.Generic;

namespace CSVMeterReadingsService.Features.Readings.Commands.ParseMeterReadings
{
    public class ParseCsvMeterReadingsCommand(IFormFile File) : IRequest<IEnumerable<MeterReadingDto>>
    {
        public IFormFile File { get; set; } = File;
    }
}