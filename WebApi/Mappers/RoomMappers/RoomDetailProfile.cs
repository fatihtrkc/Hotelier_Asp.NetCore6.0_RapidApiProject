using AutoMapper;
using DtoLayer.RoomDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.RoomMappers
{
    public class RoomDetailProfile : Profile
    {
        public RoomDetailProfile()
        {
            CreateMap<Room, RoomDetailDto>().ForMember(dest => dest.No, opt => opt.MapFrom(src => src.No));
            CreateMap<Room, RoomDetailDto>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Room, RoomDetailDto>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<Room, RoomDetailDto>().ForMember(dest => dest.CoverImage, opt => opt.MapFrom(src => src.CoverImage));
            CreateMap<Room, RoomDetailDto>().ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
            CreateMap<Room, RoomDetailDto>().ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
            CreateMap<Room, RoomDetailDto>().ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
        }
    }
}
