using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.ContactVMs;
using PresentationLayer.Models.ViewModels.SubscribeVMs;
using System.Text;

namespace PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public PartialViewResult _ContactAddPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _ContactAddPartial(ContactAddVM contactAddVM)
        {
            if (ModelState.IsValid)
            {
                var client = httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(contactAddVM);

                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7254/api/Contact/Add", stringContent);
                if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");

                return RedirectToAction("Index", "NotFound");
            }
            return PartialView(contactAddVM);
        }

        public PartialViewResult _ContactSubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _ContactSubscribePartial(SubscribeAddVM subscribeAddVM)
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
            return PartialView(subscribeAddVM);
        }
    }
}
