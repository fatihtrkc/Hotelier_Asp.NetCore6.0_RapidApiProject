using DtoLayer.CustomerDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Services.Abstract
{
    public interface ICustomerService : IGenericService<Customer, CustomerAddDto, CustomerUpdateDto>
    {
    }
}
