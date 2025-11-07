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

namespace CSVMeterReadingsService.Features.Readings.Commands.UploadReadings
{
    public class UploadMeterReadingCommandHandler(IRepository<MeterReading> repo, IMapper mapper, ILogger<UploadMeterReadingCommandHandler> logger) : IRequestHandler<UploadMeterReadingCommand, MeterReadingDto>
    {
        private readonly static ValidationFailure _failedSave = new("Meter Read", "Did not save");

        public async Task<MeterReadingDto> Handle(UploadMeterReadingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repo.InsertAsync(mapper.Map<MeterReadingDto, MeterReading>(request.MeterReadingDto));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, 
                    "Error saving meter reading to database for AccountId: {AccountId}, MeterReadingDateTime: {MeterReadingDateTime}",
                    request.MeterReadingDto.AccountId, request.MeterReadingDto.MeterReadingDateTime);
               
                request.MeterReadingDto.ValidationResult = new ValidationResult([_failedSave]);
            }

            return request.MeterReadingDto;

        }
    }
}
