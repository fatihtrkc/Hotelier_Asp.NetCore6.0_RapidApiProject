using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Booking
{
    public class _BookingSpinnerPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
