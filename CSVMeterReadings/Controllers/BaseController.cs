using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using MediatR;

namespace CSVMeterReadings.Controllers
{
    public abstract class BaseController : Controller
    {
        protected Mediator _mediator;
        protected IMapper _mapper;
        protected Presenter.Presenter _presenter;

        protected void AddErrorToModelStateErrors(ValidationResult result)
        {
            ModelState.Clear();

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
