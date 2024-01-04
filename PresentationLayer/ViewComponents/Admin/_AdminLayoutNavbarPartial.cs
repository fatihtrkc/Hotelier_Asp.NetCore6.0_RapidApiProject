using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Admin
{
    public class _AdminLayoutNavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
