﻿using BusinessLayer.Services.Abstract;
using DtoLayer.RoomDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;
        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet("Rooms")]
        public async Task<IActionResult> Index()
        {
            var rooms = await roomService.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("GetBy/{roomNo}")]
        public async Task<IActionResult> GetBy(string roomNo)
        {
            var room = await roomService.GetFirstOrDefaultAsync(r => r.No == roomNo);
            if (room is not null) return Ok(room);
            return NotFound("Room was not found !");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(RoomAddDto roomAddDto)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await roomService.AddAsync(roomAddDto);
                if (isAdded) return Ok($"{roomAddDto.No} was added successfully !");
                return BadRequest("New room adding process is unsuccess !");
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{roomNo}")]
        public async Task<IActionResult> Delete(string roomNo)
        {
            var room = await roomService.GetFirstOrDefaultAsync(r => r.No == roomNo);
            if (room is not null)
            {
                bool isDeleted = await roomService.DeleteAsync(room);
                if (isDeleted) return Ok($"{room.No} was deleted successfully !");
            }
            return BadRequest("Room is not deleted !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(RoomUpdateDto roomUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await roomService.UpdateAsync(roomUpdateDto);
                if (isUpdated) return Ok($"{roomUpdateDto.No} was updated successfully !");
                return BadRequest("Room is not updated !");
            }
            return BadRequest();
        }
    }
}
