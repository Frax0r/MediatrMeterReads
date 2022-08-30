using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using FluentValidation;

namespace CSVMeterReadingsService.Features.Readings.Commands.UploadFile
{
    public class UploadFileCommandValidator : AbstractValidator<UploadFileCommand>
    {
        private readonly List<string> _requiredFileColumns = new List<string>
            {"AccountId","MeterReadingDateTime","MeterReadValue"};

        public UploadFileCommandValidator()
        {
            RuleFor(e => e.File)
                .NotNull()
                .WithMessage("A file is required");

            RuleFor(e => e.File.FileName)
                .Must(HaveSupportedFileType)
                .When(f => f.File != null)
                .WithMessage("File must be CSV");

            RuleFor(e => e)
                .Must(HaveCorrectHeaders)
                .When(f => f.File != null)
                .WithMessage("File format incorrect");
        }

        private bool HaveSupportedFileType(string filename)
        {
            try
            {
                return Path.GetExtension(filename).Equals(".csv", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private bool HaveCorrectHeaders(UploadFileCommand request)
        {
            try
            {
                using var reader = new StreamReader(request.File.OpenReadStream());
                using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

                csvReader.Read();
                csvReader.ReadHeader();

                return !_requiredFileColumns.Except(csvReader.HeaderRecord.ToList()).Any();
            }
            catch
            {
                return false;
            }

        }
    }
}
