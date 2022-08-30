using System;
using System.Linq;
using CSVMeterReadingsService.Interfaces;
using FluentValidation.Results;

namespace CSVMeterReadingsService.Features.Readings.Models
{
    public abstract class ValidationDto : IValidationResult
    {
        public ValidationResult ValidationResult { get; set; }
        protected ValidationDto()
        {
            ValidationResult = new ValidationResult();
        }

        public string UploadResult {
            get
            {
                if (ValidationResult.IsValid)
                    return "Uploaded successfully";

                return String.Join(", ", ValidationResult.Errors.Select(e => e.ErrorMessage));

            }
        }
    }
}
