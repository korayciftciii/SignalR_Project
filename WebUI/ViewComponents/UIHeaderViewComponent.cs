using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class UIHeaderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
