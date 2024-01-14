using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.ReferenceVMs;
using System.Text;

namespace PresentationLayer.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ReferenceController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Reference/References");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var referenceListVMs = JsonConvert.DeserializeObject<IEnumerable<ReferenceListVM>>(jsonData);
                return View(referenceListVMs);
            }
            return RedirectToAction("Index", "NotFound");
        }

        [HttpGet("Reference/Detail/{referenceId}")]
        public async Task<IActionResult> Detail(int referenceId)
        //public async Task<IActionResult> Details(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Reference/GetBy/{referenceId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var referenceDetailVM = JsonConvert.DeserializeObject<ReferenceDetailVM>(jsonData);
                return View(referenceDetailVM);
            }
            return RedirectToAction("Index", "NotFound");
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReferenceAddVM referenceAddVM)
        {
            if (ModelState.IsValid)
            {
                if (referenceAddVM is not null)
                {
                    var client = httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(referenceAddVM);

                    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("https://localhost:7254/api/Reference/Add", stringContent);
                    if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
                }
            }
            return View(referenceAddVM);
        }

        [HttpGet("Reference/Delete/{referenceId}")]
        public async Task<IActionResult> Delete(int referenceId)
        //public async Task<IActionResult> Delete(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7254/api/Reference/Delete/{referenceId}");
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return RedirectToAction("Index", "NotFound");
        }

        [HttpGet("Reference/Update/{referenceId}")]
        public async Task<IActionResult> Update(int referenceId)
        //public async Task<IActionResult> Update(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Reference/GetBy/{referenceId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var referenceUpdateVM = JsonConvert.DeserializeObject<ReferenceUpdateVM>(jsonData);
                return View(referenceUpdateVM);
            }
            return RedirectToAction("Index", "NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ReferenceUpdateVM referenceUpdateVM)
        {
            if (ModelState.IsValid)
            {
                if (referenceUpdateVM is not null)
                {
                    var client = httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(referenceUpdateVM);

                    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PutAsync("https://localhost:7254/api/Reference/Update", stringContent);
                    if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
                    return RedirectToAction("Index", "NotFound");
                }
            }
            return View(referenceUpdateVM);
        }
    }
}