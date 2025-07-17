using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/404")]
        public IActionResult NotFoundPage()
        {
            ViewData["Title"] = "Page Not Found";
            return View();
        }
    }
}
