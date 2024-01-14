using BusinessLayer.Services.Abstract;
using DtoLayer.SubscribeDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService subscribeService;
        public SubscribeController(ISubscribeService subscribeService)
        {
            this.subscribeService = subscribeService;
        }

        [HttpGet("Subscribes")]
        public async Task<IActionResult> Index()
        {
            var subscribes = await subscribeService.GetAllAsync();
            return Ok(subscribes);
        }

        [HttpGet("GetBy/{subscribeId}")]
        public async Task<IActionResult> GetBy(int subscribeId)
        {
            var subscribe = await subscribeService.GetFirstOrDefaultAsync(s => s.Id == subscribeId);
            if (subscribe is not null) return Ok(subscribe);
            return NotFound("Subscribe was not found !");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(SubscribeAddDto subscribeAddDto)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await subscribeService.AddAsync(subscribeAddDto);
                if (isAdded) return Ok($"{subscribeAddDto.Email} was added successfully !");
                return BadRequest("New subscribe adding process is unsuccess !");
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{subscribeId}")]
        public async Task<IActionResult> Delete(int subscribeId)
        {
            var subscribe = await subscribeService.GetFirstOrDefaultAsync(s => s.Id == subscribeId);
            if (subscribe is not null)
            {
                bool isDeleted = await subscribeService.DeleteAsync(subscribe);
                if (isDeleted) return Ok($"{subscribe.Id} is {subscribe.Email} was deleted successfully !");
            }
            return BadRequest("Subscribe is not deleted !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(SubscribeUpdateDto subscribeUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await subscribeService.UpdateAsync(subscribeUpdateDto);
                if (isUpdated) return Ok($"{subscribeUpdateDto.Id} is {subscribeUpdateDto.Email} was updated successfully !");
                return BadRequest("Subscribe is not updated !");
            }
            return BadRequest();
        }
    }
}
