using BusinessLayer.Services.Abstract;
using BusinessLayer.Services.Concrete;
using DtoLayer.AboutDtos;
using DtoLayer.CustomerDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("Customers")]
        public async Task<IActionResult> Index()
        {
            var customers = await customerService.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("GetBy/{customerId}")]
        public async Task<IActionResult> GetBy(int customerId)
        {
            var customer = await customerService.GetFirstOrDefaultAsync(e => e.Id == customerId);
            if (customer is not null) return Ok(customer);
            return NotFound("Customer was not found !");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CustomerAddDto customerAddDto)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await customerService.AddAsync(customerAddDto);
                if (isAdded) return Ok($"{customerAddDto.Name} {customerAddDto.Surname} was added successfully !");
                return BadRequest("New customer adding process is unsuccess !");
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        {
            var customer = await customerService.GetFirstOrDefaultAsync(e => e.Id == customerId);
            if (customer is not null)
            {
                bool isDeleted = await customerService.DeleteAsync(customer);
                if (isDeleted) return Ok($"{customer.Name} {customer.Surname} was deleted successfully !");
            }
            return BadRequest("Customer is not deleted !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CustomerUpdateDto customerUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await customerService.UpdateAsync(customerUpdateDto);
                if (isUpdated) return Ok($"{customerUpdateDto.Name} {customerUpdateDto.Surname} was updated successfully !");
                return BadRequest("Customer is not updated !");
            }
            return BadRequest();
        }
    }
}
