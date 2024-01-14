using BusinessLayer.Services.Abstract;
using DtoLayer.ReferenceDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        private readonly IReferenceService referenceService;
        public ReferenceController(IReferenceService referenceService)
        {
            this.referenceService = referenceService;
        }

        [HttpGet("References")]
        public async Task<IActionResult> Index()
        {
            var references = await referenceService.GetAllAsync();
            return Ok(references);
        }

        [HttpGet("GetBy/{referenceId}")]
        public async Task<IActionResult> GetBy(int referenceId)
        {
            var reference = await referenceService.GetFirstOrDefaultAsync(t => t.Id == referenceId);
            if (reference is not null) return Ok(reference);
            return NotFound("Reference was not found !");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ReferenceAddDto referenceAddDto)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await referenceService.AddAsync(referenceAddDto);
                if (isAdded) return Ok($"{referenceAddDto.FullName} is {referenceAddDto.Title} was added successfully !");
                return BadRequest("New reference adding process is unsuccess !");
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{referenceId}")]
        public async Task<IActionResult> Delete(int referenceId)
        {
            var reference = await referenceService.GetFirstOrDefaultAsync(t => t.Id == referenceId);
            if (reference is not null)
            {
                bool isDeleted = await referenceService.DeleteAsync(reference);
                if (isDeleted) return Ok($"{reference.FullName} is {reference.Title} was deleted successfully !");
            }
            return BadRequest("Reference is not deleted !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ReferenceUpdateDto referenceUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await referenceService.UpdateAsync(referenceUpdateDto);
                if (isUpdated) return Ok($"{referenceUpdateDto.FullName} is {referenceUpdateDto.Title} was updated successfully !");
                return BadRequest("Reference is not updated !");
            }
            return BadRequest();
        }
    }
}
