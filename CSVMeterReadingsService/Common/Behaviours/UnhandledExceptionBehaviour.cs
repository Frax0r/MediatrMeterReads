using System;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CSVMeterReadingsService.Common.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;

                _logger.LogError(ex, "MeterReadings Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

                throw;
            }
        }
    }
}
