using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Home
{
    public class _HomeCarouselPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
