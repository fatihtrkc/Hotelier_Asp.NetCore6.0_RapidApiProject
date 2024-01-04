using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Admin
{
    public class _AdminLayoutScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
