using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.RoomVMs;
using System.Text;

namespace PresentationLayer.Controllers
{
    public class RoomController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public RoomController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Room/Rooms");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var roomListVMs = JsonConvert.DeserializeObject<IEnumerable<RoomListVM>>(jsonData);
                return View(roomListVMs);
            }
            return RedirectToAction("Index", "NotFound");
        }

        [HttpGet("Room/Detail/{roomNo}")]
        public async Task<IActionResult> Detail(string roomNo)
        //public async Task<IActionResult> Detail(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Room/GetBy/{roomNo}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var roomDetailVM = JsonConvert.DeserializeObject<RoomDetailVM>(jsonData);
                return View(roomDetailVM);
            }
            return RedirectToAction("Index", "NotFound");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoomAddVM roomAddVM)
        {
            if (ModelState.IsValid)
            {
                if (roomAddVM is not null)
                {
                    var client = httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(roomAddVM);

                    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("https://localhost:7254/api/Room/Add", stringContent);
                    if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
                }
            }
            return View(roomAddVM);
        }

        [HttpGet("Room/Delete/{roomNo}")]
        public async Task<IActionResult> Delete(int roomNo)
        //public async Task<IActionResult> Delete(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7254/api/Room/Delete/{roomNo}");
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return RedirectToAction("Index", "NotFound");
        }

        [HttpGet("Room/Update/{roomNo}")]
        public async Task<IActionResult> Update(int roomNo)
        //public async Task<IActionResult> Update(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Room/GetBy/{roomNo}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var roomUpdateVM = JsonConvert.DeserializeObject<RoomUpdateVM>(jsonData);
                return View(roomUpdateVM);
            }
            return RedirectToAction("Index", "NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoomUpdateVM roomUpdateVM)
        {
            if (ModelState.IsValid)
            {
                if (roomUpdateVM is not null)
                {
                    var client = httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(roomUpdateVM);

                    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PutAsync("https://localhost:7254/api/Room/Update", stringContent);
                    if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
                    return RedirectToAction("Index", "NotFound");
                }
            }
            return View(roomUpdateVM);
        }
    }
}
