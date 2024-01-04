using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Admin
{
    public class _AdminLayoutSidebarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
