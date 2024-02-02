using BusinessLayer.Services.Abstract;
using DtoLayer.BookingDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;
        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet("Bookings")]
        public async Task<IActionResult> Index()
        {
            var bookings = await bookingService.GetAllAsync();
            return Ok(bookings);
        }

        [HttpGet("GetBy/{bookingId}")]
        public async Task<IActionResult> GetBy(int bookingId)
        {
            var booking = await bookingService.GetFirstOrDefaultAsync(e => e.Id == bookingId);
            if (booking is not null) return Ok(booking);

            return NotFound("Booking was not found !");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(BookingAddDto bookingAddDto)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await bookingService.AddAsync(bookingAddDto);
                if (isAdded) return Ok($"{bookingAddDto.FullName}, your booking was added successfully !");

                return BadRequest("New booking adding process is unsuccess !");
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{bookingId}")]
        public async Task<IActionResult> Delete(int bookingId)
        {
            var booking = await bookingService.GetFirstOrDefaultAsync(e => e.Id == bookingId);
            if (booking is not null)
            {
                bool isDeleted = await bookingService.DeleteAsync(booking);
                if (isDeleted) return Ok($"{booking.FullName}, your booking was deleted successfully !");
            }
            return BadRequest("Booking is not deleted !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(BookingUpdateDto bookingUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await bookingService.UpdateAsync(bookingUpdateDto);
                if (isUpdated) return Ok($"{bookingUpdateDto.Id}, your booking was updated successfully !");

                return BadRequest("Booking is not updated !");
            }
            return BadRequest();
        }
    }
}
