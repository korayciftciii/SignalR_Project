using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class UIBookingSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
