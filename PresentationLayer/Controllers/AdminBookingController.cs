using EntityLayer.Concrete;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.BookingVMs;
using System.Text;

namespace PresentationLayer.Controllers
{
    public class AdminBookingController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public AdminBookingController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Booking/Bookings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var bookingListVMs = JsonConvert.DeserializeObject<IEnumerable<BookingListVM>>(jsonData);
                return View(bookingListVMs);
            }
            return RedirectToAction("Index", "NotFound");
        }

        [HttpGet("AdminBooking/Confirm/{bookingId}")]
        public async Task<IActionResult> Confirm(int bookingId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Booking/GetBy/{bookingId}");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var bookingUpdateVM = JsonConvert.DeserializeObject<BookingUpdateVM>(jsonData);

                bookingUpdateVM.Status = Status.Confirmed;
                jsonData = JsonConvert.SerializeObject(bookingUpdateVM);

                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                responseMessage = await client.PutAsync("https://localhost:7254/api/Booking/Update", stringContent);
                if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "NotFound");
        }

        [HttpGet("AdminBooking/Reject/{bookingId}")]
        public async Task<IActionResult> Reject(int bookingId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Booking/GetBy/{bookingId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var bookingUpdateVM = JsonConvert.DeserializeObject<BookingUpdateVM>(jsonData);

                bookingUpdateVM.Status = Status.Rejected;
                jsonData = JsonConvert.SerializeObject(bookingUpdateVM);

                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                responseMessage = await client.PutAsync("https://localhost:7254/api/Booking/Update", stringContent);
                if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "NotFound");
        }
    }
}
