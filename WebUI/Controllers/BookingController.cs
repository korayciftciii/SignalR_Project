using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Booking";
            return View();
        }
    }
}
