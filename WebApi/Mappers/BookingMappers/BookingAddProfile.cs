using AutoMapper;
using DtoLayer.BookingDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.BookingMappers
{
    public class BookingAddProfile :Profile
    {
        public BookingAddProfile()
        {
            CreateMap<BookingAddDto, Booking>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<BookingAddDto, Booking>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<BookingAddDto, Booking>().ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType));
            CreateMap<BookingAddDto, Booking>().ForMember(dest => dest.AdultCount, opt => opt.MapFrom(src => src.AdultCount));
            CreateMap<BookingAddDto, Booking>().ForMember(dest => dest.ChildCount, opt => opt.MapFrom(src => src.ChildCount));
            CreateMap<BookingAddDto, Booking>().ForMember(dest => dest.Request, opt => opt.MapFrom(src => src.Request));
            CreateMap<BookingAddDto, Booking>().ForMember(dest => dest.ChechIn, opt => opt.MapFrom(src => src.ChechIn));
            CreateMap<BookingAddDto, Booking>().ForMember(dest => dest.ChechOut, opt => opt.MapFrom(src => src.ChechOut));
        }
    }
}
