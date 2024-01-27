using DtoLayer.ReferenceDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Services.Abstract
{
    public interface IReferenceService : IGenericService<Reference, ReferenceAddDto, ReferenceUpdateDto>
    {
    }
}
