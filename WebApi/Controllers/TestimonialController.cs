using BusinessLayer.Services.Abstract;
using BusinessLayer.Services.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }

        [HttpGet("Testimonials")]
        public async Task<IActionResult> Index()
        {
            var testimonials = await testimonialService.GetAllAsync();
            return Ok(testimonials);
        }

        [HttpGet("GetBy / {testimonialId}")]
        public async Task<IActionResult> GetBy(int testimonialId)
        {
            var testimonial = await testimonialService.GetFirstOrDefaultAsync(t => t.Id == testimonialId);
            if (testimonial is not null) return Ok(testimonial);
            return NotFound("Testimonial was not found !");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(Testimonial testimonial)
        {
            bool isAdded = await testimonialService.AddAsync(testimonial);
            if (isAdded) return Ok($"{testimonial.FullName} is {testimonial.Title} was added successfully !");
            return BadRequest("New testimonial adding process is unsuccess !");
        }

        [HttpDelete("Delete / {testimonialId}")]
        public async Task<IActionResult> Delete(int testimonialId)
        {
            var testimonial = await testimonialService.GetFirstOrDefaultAsync(t => t.Id == testimonialId);
            if (testimonial is not null)
            {
                bool isDeleted = await testimonialService.DeleteAsync(testimonial);
                if (isDeleted) return Ok($"{testimonial.FullName} is {testimonial.Title} was deleted successfully !");
            }
            return BadRequest("Testimonial is not deleted !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Testimonial testimonial)
        {
            bool isUpdated = await testimonialService.UpdateAsync(testimonial);
            if (isUpdated) return Ok($"{testimonial.FullName} is {testimonial.Title} was updated successfully !");
            return BadRequest("Testimonial is not updated !");
        }
    }
}
