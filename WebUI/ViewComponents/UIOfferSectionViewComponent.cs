using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class UIOfferSectionViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
}
