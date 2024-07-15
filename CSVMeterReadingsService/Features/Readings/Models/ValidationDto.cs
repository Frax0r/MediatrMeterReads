using CSVMeterReadingsService.Interfaces;
using FluentValidation.Results;

namespace CSVMeterReadingsService.Features.Readings.Models
{
    public abstract class ValidationDto : IValidationResult
    {
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();    

    }
}
