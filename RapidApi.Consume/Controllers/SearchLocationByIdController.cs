using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Consume.Models.SearchLocationByIdVMs;

namespace RapidApi.Consume.Controllers
{
    public class SearchLocationByIdController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrWhiteSpace(cityName))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
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
                    var searchLocationByIdFindVM = JsonConvert.DeserializeObject<IEnumerable<SearchLocationByIdFindVM>>(body);

                    return View(searchLocationByIdFindVM);
                }
            }
            return View(null);
        }
    }
}
