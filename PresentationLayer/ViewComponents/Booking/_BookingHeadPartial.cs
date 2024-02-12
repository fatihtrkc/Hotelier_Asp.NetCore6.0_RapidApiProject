using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Booking
{
    public class _BookingHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
