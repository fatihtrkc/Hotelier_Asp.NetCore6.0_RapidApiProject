using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Contact
{
    public class _ContactPageHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
