using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
    }
}
