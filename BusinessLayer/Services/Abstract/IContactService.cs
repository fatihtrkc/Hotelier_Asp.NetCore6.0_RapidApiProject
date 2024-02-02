using DtoLayer.ContactDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Services.Abstract
{
    public interface IContactService : IGenericService<Contact, ContactAddDto, ContactUpdateDto>
    {
    }
}
