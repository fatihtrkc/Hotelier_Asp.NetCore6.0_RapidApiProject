using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
