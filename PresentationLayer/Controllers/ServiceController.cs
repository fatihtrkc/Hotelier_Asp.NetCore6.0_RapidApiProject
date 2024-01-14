using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.ServiceVMs;
using System.Text;

namespace PresentationLayer.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Service/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var serviceListVMs = JsonConvert.DeserializeObject<IEnumerable<ServiceListVM>>(jsonData);
                return View(serviceListVMs);
            }
            return RedirectToAction("Index", "NotFound");
        }

        [HttpGet("Service/Detail/{serviceName}")]
        public async Task<IActionResult> Detail(string serviceName)
        //public async Task<IActionResult> Detail(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Service/GetBy/{serviceName}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var serviceDetailVM = JsonConvert.DeserializeObject<ServiceDetailVM>(jsonData);
                return View(serviceDetailVM);
            }
            return RedirectToAction("Index", "NotFound");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ServiceAddVM serviceAddVM)
        {
            if (ModelState.IsValid)
            {
                if (serviceAddVM is not null)
                {
                    var client = httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(serviceAddVM);

                    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("https://localhost:7254/api/Service/Add", stringContent);
                    if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
                }
            }
            return View(serviceAddVM);
        }

        [HttpGet("Service/Delete/{serviceName}")]
        public async Task<IActionResult> Delete(string serviceName)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7254/api/Service/Delete/{serviceName}");
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return RedirectToAction("Index", "NotFound");
        }

        [HttpGet("Service/Update/{serviceName}")]
        public async Task<IActionResult> Update(string serviceName)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Service/GetBy/{serviceName}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var serviceUpdateVM = JsonConvert.DeserializeObject<ServiceUpdateVM>(jsonData);
                return View(serviceUpdateVM);
            }
            return RedirectToAction("Index", "NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ServiceUpdateVM serviceUpdateVM)
        {
            if (ModelState.IsValid)
            {
                if (serviceUpdateVM is not null)
                {
                    var client = httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(serviceUpdateVM);

                    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PutAsync("https://localhost:7254/api/Service/Update", stringContent);
                    if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
                    return RedirectToAction("Index", "NotFound");
                }
            }
            return View(serviceUpdateVM);
        }
    }
}
