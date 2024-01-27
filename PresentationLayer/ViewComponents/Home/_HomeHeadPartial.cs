using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Home
{
    public class _HomeHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
