using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents
{
    public class AdminSideBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var controller = RouteData?.Values["controller"]?.ToString();
     

            ViewBag.CurrentController = controller;
           
            return View();
        }
    }
}
