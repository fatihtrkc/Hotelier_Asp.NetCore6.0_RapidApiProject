using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Admin
{
    public class _AdminLayoutHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
