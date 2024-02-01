using DtoLayer.AboutDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Services.Abstract
{
    public interface IAboutService : IGenericService<About, AboutAddDto, AboutUpdateDto>
    {
    }
}
