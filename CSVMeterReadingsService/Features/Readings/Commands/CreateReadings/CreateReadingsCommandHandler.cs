using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSVMeterReadingsModels;
using CSVMeterReadingsService.Features.Readings.Models;
using FluentValidation.Results;
using MediatR;
using Repository.Interfaces;

namespace CSVMeterReadingsService.Features.Readings.Commands.CreateReadings
{
    public class CreateReadingsCommandHandler(IRepository<MeterReading> repo, IMapper mapper) : IRequestHandler<CreateReadingsCommand, MeterReadingDto>
    {
        private readonly static ValidationFailure _failedSave = new("Meter Read", "Did not save");

        public async Task<MeterReadingDto> Handle(CreateReadingsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repo.InsertAsync(mapper.Map<MeterReadingDto, MeterReading>(request.MeterReading));       
            }
            catch
            {
                request.MeterReading.ValidationResult = new ValidationResult(new List<ValidationFailure> { _failedSave });              
            }

            return request.MeterReading;

        }
    }
}
