using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class UILoginFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
