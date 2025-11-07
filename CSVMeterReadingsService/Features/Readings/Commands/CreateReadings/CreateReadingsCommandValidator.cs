using FluentValidation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CSVMeterReadingsModels;
using CSVMeterReadingsService.Features.Readings.Models;
using Repository.Interfaces;

namespace CSVMeterReadingsService.Features.Readings.Commands.CreateReadings
{
    public partial class CreateReadingsCommandValidator : AbstractValidator<CreateReadingsCommand>
    {
        private readonly IRepository<MeterReading> _meterReadingRepo;
        private readonly IRepository<Account> _accountRepo;

        public CreateReadingsCommandValidator(IRepository<MeterReading> meterReadingRepo, IRepository<Account> accountRepo)
        {
            _meterReadingRepo = meterReadingRepo;
            _accountRepo = accountRepo;

            RuleFor(e => e.MeterReading.AccountId)
                .MustAsync(ValidateAccountIdAsync)
                .WithMessage("Account does not exist for meter reading");

            RuleFor(e => e.MeterReading.MeterReadValue)
                .Must(ValidateReadingFormat)
                .WithMessage("Meter reading format invalid");

            RuleFor(e => e.MeterReading)
                .MustAsync(ValidateMeterReadingAsync)
                .WithMessage("Meter reading already exists");
        }

        private async Task<bool> ValidateAccountIdAsync(ulong accountId, CancellationToken cancellationToken)
        {
            return await _accountRepo.GetByIDAsync(accountId, cancellationToken) != null;
        }

        private bool ValidateReadingFormat(string readingValue)
        {
            return NumericRegex().IsMatch(readingValue);
        }

        private async Task<bool> ValidateMeterReadingAsync(MeterReadingDto meterReading, CancellationToken cancellationToken)
        {
            return await _meterReadingRepo.FindAsync([meterReading.AccountId, meterReading.MeterReadingDateTime], cancellationToken) == null;
        }

        [GeneratedRegex(@"^[0-9]{1,5}$")]
        private static partial Regex NumericRegex();
    }
}
