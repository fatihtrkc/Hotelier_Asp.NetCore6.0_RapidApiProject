using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Contact
{
    public class _ContactHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
