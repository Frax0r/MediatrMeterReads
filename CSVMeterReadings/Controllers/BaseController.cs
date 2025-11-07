using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

namespace CSVMeterReadingsAPI.Controllers
{
    public abstract class BaseController() : Controller
    {
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
