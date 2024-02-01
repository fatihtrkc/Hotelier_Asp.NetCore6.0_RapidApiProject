using AutoMapper;
using DtoLayer.BookingDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.BookingMappers
{
    public class BookingListProfile : Profile
    {
        public BookingListProfile() 
        {
            CreateMap<Booking, BookingListDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Booking, BookingListDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<Booking, BookingListDto>().ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType));
            CreateMap<Booking, BookingListDto>().ForMember(dest => dest.ChechIn, opt => opt.MapFrom(src => src.ChechIn));
            CreateMap<Booking, BookingListDto>().ForMember(dest => dest.ChechOut, opt => opt.MapFrom(src => src.ChechOut));
            CreateMap<Booking, BookingListDto>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
