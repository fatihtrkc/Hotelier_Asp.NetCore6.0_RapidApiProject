using BusinessLayer.Services.Abstract;
using DtoLayer.ServiceDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService serviceService;
        public ServiceController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        [HttpGet("Services")]
        public async Task<IActionResult> Index()
        {
            var services = await serviceService.GetAllAsync();
            return Ok(services);
        }

        [HttpGet("GetBy/{serviceName}")]
        public async Task<IActionResult> GetBy(string serviceName)
        {
            var service = await serviceService.GetFirstOrDefaultAsync(s => s.Name == serviceName);
            if (service is not null) return Ok(service);
            return NotFound("Service was not found !");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ServiceAddDto serviceAddDto)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await serviceService.AddAsync(serviceAddDto);
                if (isAdded) return Ok($"{serviceAddDto.Name} was added successfully !");
                return BadRequest("New Service adding process is unsuccess !");
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{serviceName}")]
        public async Task<IActionResult> Delete(string serviceName)
        {
            var service = await serviceService.GetFirstOrDefaultAsync(s => s.Name == serviceName);
            if (service is not null)
            {
                bool isDeleted = await serviceService.DeleteAsync(service);
                if (isDeleted) return Ok($"{service.Name} was deleted successfully !");
            }
            return BadRequest("Service is not deleted !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ServiceUpdateDto serviceUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await serviceService.UpdateAsync(serviceUpdateDto);
                if (isUpdated) return Ok($"{serviceUpdateDto.Name} was updated successfully !");
                return BadRequest("Service is not updated !");
            }
            return BadRequest();
        }
    }
}
