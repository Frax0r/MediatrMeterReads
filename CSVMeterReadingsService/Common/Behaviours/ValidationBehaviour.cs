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
    public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse> where TResponse : IValidationResult, new()
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(
                   validators.Select(v =>
                        v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .Where(r => !r.IsValid)
                    .SelectMany(r => r.Errors)
                    .ToList();

                if (failures.Count != 0)
                {
                    return new TResponse { ValidationResult = new ValidationResult(failures) };
                }
            }
            return await next(cancellationToken);
        }
    }
}
