using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using MediatR;

namespace CSVMeterReadings.Controllers
{
    public abstract class BaseController(IMediator mediator) : Controller
    {
        protected Mediator _mediator { get; } = (Mediator)mediator;
        protected void AddErrorsToModelState(ValidationResult result)
        {
            ModelState.Clear();

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
