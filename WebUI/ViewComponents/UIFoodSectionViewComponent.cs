using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class UIFoodSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
