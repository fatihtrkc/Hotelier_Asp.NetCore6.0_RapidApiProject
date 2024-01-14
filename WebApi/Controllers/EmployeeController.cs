using BusinessLayer.Services.Abstract;
using DtoLayer.EmployeeDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("Employees")]
        public async Task<IActionResult> Index()
        {
            var employees = await employeeService.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("GetBy/{employeeId}")]
        public async Task<IActionResult> GetBy(int employeeId)
        {
            var employee = await employeeService.GetFirstOrDefaultAsync(e => e.Id == employeeId);
            if (employee is not null) return Ok(employee);
            return NotFound("Employee was not found !");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(EmployeeAddDto employeeAddDto)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await employeeService.AddAsync(employeeAddDto);
                if (isAdded) return Ok($"{employeeAddDto.FullName} is {employeeAddDto.Title} was added successfully !");
                return BadRequest("New employee adding process is unsuccess !");
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{employeeId}")]
        public async Task<IActionResult> Delete(int employeeId)
        {
            var employee = await employeeService.GetFirstOrDefaultAsync(e => e.Id == employeeId);
            if (employee is not null)
            {
                bool isDeleted = await employeeService.DeleteAsync(employee);
                if (isDeleted) return Ok($"{employee.FullName} is {employee.Title} was deleted successfully !");
            }
            return BadRequest("Employee is not deleted !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EmployeeUpdateDto employeeUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await employeeService.UpdateAsync(employeeUpdateDto);
                if (isUpdated) return Ok($"{employeeUpdateDto.FullName} is {employeeUpdateDto.Title} was updated successfully !");
                return BadRequest("Employee is not updated !");
            }
            return BadRequest();
        }
    }
}
