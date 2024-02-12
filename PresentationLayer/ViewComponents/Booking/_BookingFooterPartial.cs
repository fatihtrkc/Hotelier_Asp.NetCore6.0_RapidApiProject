using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Booking
{
    public class _BookingFooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
