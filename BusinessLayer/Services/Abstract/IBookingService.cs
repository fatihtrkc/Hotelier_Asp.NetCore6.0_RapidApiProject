using DtoLayer.BookingDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Services.Abstract
{
    public interface IBookingService : IGenericService<Booking, BookingAddDto, BookingUpdateDto>
    {
    }
}
