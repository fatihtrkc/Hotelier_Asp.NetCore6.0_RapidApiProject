﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Consume.Models.BookingComHotelVMs;

namespace RapidApi.Consume.Controllers
{
    public class BookingByCityController : Controller
    {
        public async Task<IActionResult> Index(string cityId)
        {
            if (!string.IsNullOrWhiteSpace(cityId))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?room_number=1&adults_number=2&checkout_date=2024-05-20&filter_by_currency=AED&units=metric&locale=en-gb&checkin_date=2024-05-19&dest_type=city&dest_id={cityId}&order_by=popularity&children_ages=5%2C0&children_number=2&include_adjacency=true&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&page_number=0"),
                    Headers =
    {
        { "X-RapidAPI-Key", "9f80923f77mshcd44254fb50627fp12d64ajsnb3f87311c348" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var bookingComHotelListVM = JsonConvert.DeserializeObject<BookingComHotelListVM>(body);
                    return View(bookingComHotelListVM.results);
                }
            }
            return View(null);
        }
    }
}
