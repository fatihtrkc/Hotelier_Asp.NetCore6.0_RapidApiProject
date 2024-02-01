using BusinessLayer.Services.Abstract;
using DtoLayer.AboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService aboutService;
        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        [HttpGet("Abouts")]
        public async Task<IActionResult> Index()
        {
            var abouts = await aboutService.GetAllAsync();
            return Ok(abouts);
        }

        [HttpGet("GetBy/{aboutId}")]
        public async Task<IActionResult> GetBy(int aboutId)
        {
            var about = await aboutService.GetFirstOrDefaultAsync(e => e.Id == aboutId);
            if (about is not null) return Ok(about);
            return NotFound("About was not found !");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AboutAddDto aboutAddDto)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await aboutService.AddAsync(aboutAddDto);
                if (isAdded) return Ok($"{aboutAddDto.Title} was added successfully !");
                return BadRequest("New about adding process is unsuccess !");
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{aboutId}")]
        public async Task<IActionResult> Delete(int aboutId)
        {
            var about = await aboutService.GetFirstOrDefaultAsync(e => e.Id == aboutId);
            if (about is not null)
            {
                bool isDeleted = await aboutService.DeleteAsync(about);
                if (isDeleted) return Ok($"{about.Title} was deleted successfully !");
            }
            return BadRequest("About is not deleted !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(AboutUpdateDto aboutUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await aboutService.UpdateAsync(aboutUpdateDto);
                if (isUpdated) return Ok($"{aboutUpdateDto.Title} was updated successfully !");
                return BadRequest("About is not updated !");
            }
            return BadRequest();
        }
    }
}
