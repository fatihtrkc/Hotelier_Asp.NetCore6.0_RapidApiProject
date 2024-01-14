using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class NotFoundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
