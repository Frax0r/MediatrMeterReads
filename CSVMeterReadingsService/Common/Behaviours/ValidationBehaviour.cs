using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSVMeterReadingsService.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CSVMeterReadingsService.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse> where TResponse : IValidationResult, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(
                   _validators.Select(v =>
                        v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .Where(r => r.Errors.Any())
                    .SelectMany(r => r.Errors)
                    .ToList();

                if (failures.Any())
                {
                    return new TResponse { ValidationResult = new ValidationResult(failures) };
                }
            }
            return await next();
        }
    }
}
