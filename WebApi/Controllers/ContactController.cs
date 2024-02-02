using BusinessLayer.Services.Abstract;
using DtoLayer.ContactDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet("Contacts")]
        public async Task<IActionResult> Index()
        {
            var contacts = await contactService.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet("GetBy/{contactId}")]
        public async Task<IActionResult> GetBy(int contactId)
        {
            var contact = await contactService.GetFirstOrDefaultAsync(e => e.Id == contactId);
            if (contact is not null) return Ok(contact);
            return NotFound("Contact was not found !");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ContactAddDto contactAddDto)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await contactService.AddAsync(contactAddDto);
                if (isAdded) return Ok($"{contactAddDto.Name} was added successfully !");
                return BadRequest("New contact adding process is unsuccess !");
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{contactId}")]
        public async Task<IActionResult> Delete(int contactId)
        {
            var contact = await contactService.GetFirstOrDefaultAsync(e => e.Id == contactId);
            if (contact is not null)
            {
                bool isDeleted = await contactService.DeleteAsync(contact);
                if (isDeleted) return Ok($"{contact.Name} was deleted successfully !");
            }
            return BadRequest("Contact is not deleted !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ContactUpdateDto contactUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await contactService.UpdateAsync(contactUpdateDto);
                if (isUpdated) return Ok($"{contactUpdateDto.Name} was updated successfully !");
                return BadRequest("Contact is not updated !");
            }
            return BadRequest();
        }
    }
}
