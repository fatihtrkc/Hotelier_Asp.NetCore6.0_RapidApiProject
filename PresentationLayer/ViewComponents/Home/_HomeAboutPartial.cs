using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Home
{
    public class _HomeAboutPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
