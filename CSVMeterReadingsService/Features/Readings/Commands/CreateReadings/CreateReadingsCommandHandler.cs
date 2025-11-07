using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSVMeterReadingsModels;
using CSVMeterReadingsService.Features.Readings.Models;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;

namespace CSVMeterReadingsService.Features.Readings.Commands.CreateReadings
{
    public class CreateReadingsCommandHandler(IRepository<MeterReading> repo, IMapper mapper, ILogger<CreateReadingsCommandHandler> logger) : IRequestHandler<CreateReadingsCommand, MeterReadingDto>
    {
        private readonly static ValidationFailure _failedSave = new("Meter Read", "Did not save");

        public async Task<MeterReadingDto> Handle(CreateReadingsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repo.InsertAsync(mapper.Map<MeterReadingDto, MeterReading>(request.MeterReading));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, 
                    "Error saving meter reading to database for AccountId: {AccountId}, MeterReadingDateTime: {MeterReadingDateTime}",
                    request.MeterReading.AccountId, request.MeterReading.MeterReadingDateTime);
               
                request.MeterReading.ValidationResult = new ValidationResult([_failedSave]);
            }

            return request.MeterReading;

        }
    }
}
