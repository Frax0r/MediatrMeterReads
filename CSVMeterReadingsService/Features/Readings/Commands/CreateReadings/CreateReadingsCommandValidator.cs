using FluentValidation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CSVMeterReadings.Models;
using CSVMeterReadingsService.Features.Readings.Models;
using Repository.Interfaces;

namespace CSVMeterReadingsService.Features.Readings.Commands.CreateReadings
{
    public class CreateReadingsCommandValidator : AbstractValidator<CreateReadingsCommand>
    {
        private readonly IRepository<MeterReading> _meterReadingRepo;
        private readonly IRepository<Account> _accountRepo;

        public CreateReadingsCommandValidator(IRepository<MeterReading> meterReadingRepo, IRepository<Account> accountReadingRepo)
        {
            _meterReadingRepo = meterReadingRepo;
            _accountRepo = accountReadingRepo;

            RuleFor(e => e.MeterReading.AccountId)
                .MustAsync(ValidateAccountId)
                .WithMessage("Account does not exist for meter reading");

            RuleFor(e => e.MeterReading.MeterReadValue)
                .Must(ValidateReadingFormat)
                .WithMessage("Meter reading format invalid");

            RuleFor(e => e.MeterReading)
                .MustAsync(ValidateMeterReading)
                .WithMessage("Meter reading already exists");
        }

        private async Task<bool> ValidateAccountId(ulong accountId, CancellationToken cancellationToken)
        {
            return await _accountRepo.GetByID(accountId, cancellationToken) != null;
        }

        private bool ValidateReadingFormat(string readingValue)
        {
            return Regex.IsMatch(readingValue, @"^[0-9]+$");
        }

        private async Task<bool> ValidateMeterReading(MeterReadingDto meterReading, CancellationToken cancellationToken)
        {
            return await _meterReadingRepo.Find(new object[]
                 { meterReading.AccountId, meterReading.MeterReadingDateTime }, cancellationToken) == null;
        }
    }
}
