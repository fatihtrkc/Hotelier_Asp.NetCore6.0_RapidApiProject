using DtoLayer.SubscribeDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Services.Abstract
{
    public interface ISubscribeService : IGenericService<Subscribe, SubscribeAddDto, SubscribeUpdateDto>
    {
    }
}
