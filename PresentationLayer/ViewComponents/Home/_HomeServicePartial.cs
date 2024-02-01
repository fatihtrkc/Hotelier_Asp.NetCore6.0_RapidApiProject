using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.ServiceVMs;

namespace PresentationLayer.ViewComponents.Home
{
    public class _HomeServicePartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public _HomeServicePartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Service/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var serviceListVMs = JsonConvert.DeserializeObject<IEnumerable<ServiceListVM>>(jsonData);
                return View(serviceListVMs);
            }
            return View();
        }
    }
}
