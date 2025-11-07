using FluentValidation.Results;

namespace CSVMeterReadingsAPI.ViewModel
{
    public abstract class ValidationDtoVM
    {
       public ValidationResult ValidationResult { get; set; } = new ValidationResult();
    }
}
