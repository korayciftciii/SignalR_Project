using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class UIFooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
