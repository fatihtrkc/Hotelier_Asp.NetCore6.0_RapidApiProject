using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Admin
{
    public class _AdminLayoutPreloaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
