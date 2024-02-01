using AutoMapper;
using DtoLayer.BookingDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.BookingMappers
{
    public class BookingDetailProfile : Profile
    {
        public BookingDetailProfile() 
        {
            CreateMap<Booking, BookingDetailDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Booking, BookingDetailDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<Booking, BookingDetailDto>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<Booking, BookingDetailDto>().ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType));
            CreateMap<Booking, BookingDetailDto>().ForMember(dest => dest.AdultCount, opt => opt.MapFrom(src => src.AdultCount));
            CreateMap<Booking, BookingDetailDto>().ForMember(dest => dest.ChildCount, opt => opt.MapFrom(src => src.ChildCount));
            CreateMap<Booking, BookingDetailDto>().ForMember(dest => dest.Request, opt => opt.MapFrom(src => src.Request));
            CreateMap<Booking, BookingDetailDto>().ForMember(dest => dest.ChechIn, opt => opt.MapFrom(src => src.ChechIn));
            CreateMap<Booking, BookingDetailDto>().ForMember(dest => dest.ChechOut, opt => opt.MapFrom(src => src.ChechOut));
            CreateMap<Booking, BookingDetailDto>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            CreateMap<Booking, BookingDetailDto>().ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
        }
    }
}
