using DtoLayer.ServiceDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Services.Abstract
{
    public interface IServiceService : IGenericService<Service, ServiceAddDto, ServiceUpdateDto>
    {
    }
}
