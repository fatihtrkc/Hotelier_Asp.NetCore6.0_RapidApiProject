using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.SubscribeVMs;
using System.Text;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult _FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult _ScriptPartial()
        {
            return PartialView();
        }

        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(SubscribeAddVM subscribeAddVM)
        {
            if (ModelState.IsValid)
            {
                var client = httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(subscribeAddVM);

                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7254/api/Subscribe/Add", stringContent);
                if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
                return RedirectToAction("Index", "NotFound");
            }
            return View(subscribeAddVM);
        }
    }
}
