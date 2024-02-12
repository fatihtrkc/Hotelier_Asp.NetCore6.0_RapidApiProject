using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Contact
{
    public class _ContactSpinnerPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
