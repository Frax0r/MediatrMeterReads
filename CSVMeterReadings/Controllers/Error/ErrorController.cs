using Microsoft.AspNetCore.Mvc;

namespace CSVMeterReadings.Controllers.Error
{
    public class ErrorController : Controller
    {
        [Route("/error")]
        public IActionResult Error()
        {
            return View("Error");
        }
        public IActionResult Http(int statusCode)
        {
            return statusCode switch
            {
                401 => View("Unauthorized"),
                404 => View("NotFound"),
                _ => View("Error")
            };
        }

    }
}
