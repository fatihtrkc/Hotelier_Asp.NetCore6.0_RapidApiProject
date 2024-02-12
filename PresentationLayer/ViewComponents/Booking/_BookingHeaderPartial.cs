using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Booking
{
    public class _BookingHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
