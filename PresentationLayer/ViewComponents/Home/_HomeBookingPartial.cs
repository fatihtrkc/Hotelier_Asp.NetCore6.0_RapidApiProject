using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Home
{
    public class _HomeBookingPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
