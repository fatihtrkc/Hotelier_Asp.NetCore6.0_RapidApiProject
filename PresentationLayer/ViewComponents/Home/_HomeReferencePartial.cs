using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.ReferenceVMs;

namespace PresentationLayer.ViewComponents.Home
{
    public class _HomeReferencePartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public _HomeReferencePartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Reference/References");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var referenceListVMs = JsonConvert.DeserializeObject<IEnumerable<ReferenceListVM>>(jsonData);
                return View(referenceListVMs);
            }
            return View();
        }
    }
}
