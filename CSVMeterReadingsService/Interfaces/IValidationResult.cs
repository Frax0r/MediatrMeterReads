using FluentValidation.Results;

namespace CSVMeterReadingsService.Interfaces
{
    public interface IValidationResult
    {
        ValidationResult ValidationResult { get; set; }

        string UploadResult { get; }
    }
}
