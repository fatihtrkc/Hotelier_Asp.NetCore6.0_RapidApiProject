using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models.ViewModels.AboutVMs;
using PresentationLayer.Models.ViewModels.CustomerVMs;
using System.Text;

namespace PresentationLayer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Customer/Customers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var customerListVMs = JsonConvert.DeserializeObject<IEnumerable<CustomerListVM>>(jsonData);
                return View(customerListVMs);
            }
            return RedirectToAction("Index", "NotFound");
        }

        [HttpGet("Customer/Detail/{customerId}")]
        public async Task<IActionResult> Detail(int customerId)
        //public async Task<IActionResult> Detail(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Customer/GetBy/{customerId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var customerDetailVM = JsonConvert.DeserializeObject<CustomerDetailVM>(jsonData);
                return View(customerDetailVM);
            }
            return RedirectToAction("Index", "NotFound");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerAddVM customerAddVM)
        {
            if (ModelState.IsValid)
            {
                if (customerAddVM is not null)
                {
                    var client = httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(customerAddVM);

                    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("https://localhost:7254/api/Customer/Add", stringContent);
                    if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
                }
            }
            return View(customerAddVM);
        }

        [HttpGet("Customer/Delete/{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        //public async Task<IActionResult> Delete(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7254/api/Customer/Delete/{customerId}");
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return RedirectToAction("Index", "NotFound");
        }

        [HttpGet("Customer/Update/{customerId}")]
        public async Task<IActionResult> Update(int customerId)
        //public async Task<IActionResult> Update(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Customer/GetBy/{customerId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var customerUpdateVM = JsonConvert.DeserializeObject<CustomerUpdateVM>(jsonData);
                return View(customerUpdateVM);
            }
            return RedirectToAction("Index", "NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Update(CustomerUpdateVM customerUpdateVM)
        {
            if (ModelState.IsValid)
            {
                if (customerUpdateVM is not null)
                {
                    var client = httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(customerUpdateVM);

                    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PutAsync("https://localhost:7254/api/Customer/Update", stringContent);
                    if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
                    return RedirectToAction("Index", "NotFound");
                }
            }
            return View(customerUpdateVM);
        }
    }
}