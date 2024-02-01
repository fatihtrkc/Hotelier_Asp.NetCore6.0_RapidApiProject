using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.AboutVMs;
using System.Text;

namespace PresentationLayer.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public AboutController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/About/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var aboutListVMs = JsonConvert.DeserializeObject<IEnumerable<AboutListVM>>(jsonData);
                return View(aboutListVMs);
            }
            return RedirectToAction("Index", "NotFound");
        }

        [HttpGet("About/Detail/{aboutId}")]
        public async Task<IActionResult> Detail(int aboutId)
        //public async Task<IActionResult> Detail(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/About/GetBy/{aboutId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var aboutDetailVM = JsonConvert.DeserializeObject<AboutDetailVM>(jsonData);
                return View(aboutDetailVM);
            }
            return RedirectToAction("Index", "NotFound");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AboutAddVM aboutAddVM)
        {
            if (ModelState.IsValid)
            {
                if (aboutAddVM is not null)
                {
                    var client = httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(aboutAddVM);

                    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("https://localhost:7254/api/About/Add", stringContent);
                    if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
                }
            }
            return View(aboutAddVM);
        }

        [HttpGet("About/Delete/{aboutId}")]
        public async Task<IActionResult> Delete(int aboutId)
        //public async Task<IActionResult> Delete(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7254/api/About/GetBy/{aboutId}");
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return RedirectToAction("Index", "NotFound");
        }

        [HttpGet("About/Update/{aboutId}")]
        public async Task<IActionResult> Update(int aboutId)
        //public async Task<IActionResult> Update(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/About/GetBy/{aboutId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var aboutUpdateVM = JsonConvert.DeserializeObject<AboutUpdateVM>(jsonData);
                return View(aboutUpdateVM);
            }
            return RedirectToAction("Index", "NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Update(AboutUpdateVM aboutUpdateVM)
        {
            if (ModelState.IsValid)
            {
                if (aboutUpdateVM is not null)
                {
                    var client = httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(aboutUpdateVM);

                    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PutAsync("https://localhost:7254/api/About/Update", stringContent);
                    if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
                    return RedirectToAction("Index", "NotFound");
                }
            }
            return View(aboutUpdateVM);
        }
    }
}
