using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class UIContactFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
