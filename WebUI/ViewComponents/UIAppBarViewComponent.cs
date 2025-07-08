using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class UIAppBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var controller = RouteData?.Values["controller"]?.ToString();
            var action = RouteData?.Values["action"]?.ToString();

            ViewBag.CurrentController = controller;
            ViewBag.CurrentAction = action;

            return View();
        }
    }
}
