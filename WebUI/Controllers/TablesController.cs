using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class TablesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
