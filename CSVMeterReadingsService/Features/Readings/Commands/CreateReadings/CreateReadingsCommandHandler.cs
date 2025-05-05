using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSVMeterReadings.Models;
using CSVMeterReadingsService.Features.Readings.Models;
using FluentValidation.Results;
using MediatR;
using Repository.Interfaces;

namespace CSVMeterReadingsService.Features.Readings.Commands.CreateReadings
{
    public class CreateReadingsCommandHandler : IRequestHandler<CreateReadingsCommand, MeterReadingDto>
    {
        private readonly IRepository<MeterReading> _repo;
        private readonly IMapper _mapper;
        private readonly ValidationFailure _failedSave = new ValidationFailure("Meter Read", "Did not save");

        public CreateReadingsCommandHandler(IRepository<MeterReading> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<MeterReadingDto> Handle(CreateReadingsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repo.InsertAsync(_mapper.Map<MeterReadingDto, MeterReading>(request.MeterReading));       
            }
            catch
            {
                request.MeterReading.ValidationResult = new ValidationResult(new List<ValidationFailure> { _failedSave });              
            }

            return request.MeterReading;

        }
    }
}
