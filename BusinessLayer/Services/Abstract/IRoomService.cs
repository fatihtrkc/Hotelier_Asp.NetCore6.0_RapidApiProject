using DtoLayer.RoomDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Services.Abstract
{
    public interface IRoomService : IGenericService<Room, RoomAddDto, RoomUpdateDto>
    {
    }
}
