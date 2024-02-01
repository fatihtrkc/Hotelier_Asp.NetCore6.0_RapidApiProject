using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.AboutVMs;

namespace PresentationLayer.ViewComponents.Home
{
    public class _HomeAboutPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public _HomeAboutPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/About/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var aboutListVMs = JsonConvert.DeserializeObject<IEnumerable<AboutListVM>>(jsonData);
                return View(aboutListVMs);
            }
            //return RedirectToAction("Index", "NotFound");
            return View(null);
        }
    }
}
