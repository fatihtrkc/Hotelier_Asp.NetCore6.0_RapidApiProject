using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.RoomVMs;

namespace PresentationLayer.ViewComponents.Home
{
    public class _HomeRoomPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public _HomeRoomPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Room/Rooms");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var roomListVMs = JsonConvert.DeserializeObject<IEnumerable<RoomListVM>>(jsonData);
                return View(roomListVMs);
            }
            return View();
            //return RedirectToAction("Index", "NotFound");
        }
    }
}
