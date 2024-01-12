using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.EmployeeVMs;
using System.Text;

namespace PresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Employee/Employees");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeListVM>>(jsonData);
                return View(employees);
            }
            return NotFound();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeAddVM employeeAddVM)
        {
            if (ModelState.IsValid)
            {
                if (employeeAddVM is not null)
                {
                    var client = httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(employeeAddVM);

                    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("https://localhost:7254/api/Employee/Add", stringContent);
                    if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
                }
            }
            return View(employeeAddVM);
        }

        [HttpGet("Delete/{employeeId}")]
        public async Task<IActionResult> Delete(int employeeId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7254/api/Employee/Delete/{employeeId}");
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return RedirectToAction("Index");
        }

        [HttpGet("Update/{employeeId}")]
        public async Task<IActionResult> Update(int employeeId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Employee/GetBy/{employeeId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var employeeUpdateVM = JsonConvert.DeserializeObject<EmployeeUpdateVM>(jsonData);
                return View(employeeUpdateVM);
            }
            //return NotFound();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeUpdateVM employeeUpdateVM)
        {
            var client = httpClientFactory.CreateClient();
            return View();
        }
    }
}
