using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class UIRegisterFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
