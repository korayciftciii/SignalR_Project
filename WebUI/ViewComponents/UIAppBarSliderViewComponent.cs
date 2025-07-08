using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class UIAppBarSliderViewComponent : ViewComponent

    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
