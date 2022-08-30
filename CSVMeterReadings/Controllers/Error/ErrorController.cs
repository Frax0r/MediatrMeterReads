using Microsoft.AspNetCore.Mvc;

namespace CSVMeterReadings.Controllers.Error
{
    public class ErrorController : Controller
    {
        public IActionResult Http(int statusCode)
        {
            return statusCode == 404 ? View("NotFound") : View("Error");
        }

    }
}
