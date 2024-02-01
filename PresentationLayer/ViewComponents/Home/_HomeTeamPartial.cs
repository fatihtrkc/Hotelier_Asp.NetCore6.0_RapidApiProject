using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.EmployeeVMs;

namespace PresentationLayer.ViewComponents.Home
{
    public class _HomeTeamPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public _HomeTeamPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Employee/Employees");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var employeeListVMs = JsonConvert.DeserializeObject<IEnumerable<EmployeeListVM>>(jsonData);
                return View(employeeListVMs);
            }
            return View();
            //return RedirectToAction("Index", "NotFound");
        }
    }
}
