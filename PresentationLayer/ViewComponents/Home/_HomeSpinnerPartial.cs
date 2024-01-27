using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Home
{
    public class _HomeSpinnerPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
