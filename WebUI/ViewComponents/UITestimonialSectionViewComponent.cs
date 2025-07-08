using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class UITestimonialSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
}
