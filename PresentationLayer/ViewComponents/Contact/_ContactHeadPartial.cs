using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Contact
{
    public class _ContactHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
