using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents
{
    public class AdminScriptsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
