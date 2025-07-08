using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class UIScriptsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
