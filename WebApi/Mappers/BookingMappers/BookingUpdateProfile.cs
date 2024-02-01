using AutoMapper;
using DtoLayer.BookingDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.BookingMappers
{
    public class BookingUpdateProfile : Profile
    {
        public BookingUpdateProfile() 
        {
            CreateMap<Booking, BookingUpdateDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Booking, BookingUpdateDto>().ReverseMap().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
