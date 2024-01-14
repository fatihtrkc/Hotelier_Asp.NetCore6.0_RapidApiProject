using AutoMapper;
using DtoLayer.RoomDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.RoomMappers
{
    public class RoomAddProfile : Profile
    {
        public RoomAddProfile()
        {
            CreateMap<RoomAddDto, Room>().ForMember(dest => dest.No, opt => opt.MapFrom(src => src.No));
            CreateMap<RoomAddDto, Room>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<RoomAddDto, Room>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<RoomAddDto, Room>().ForMember(dest => dest.CoverImage, opt => opt.MapFrom(src => src.CoverImage));
            CreateMap<RoomAddDto, Room>().ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
            CreateMap<RoomAddDto, Room>().ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
        }
    }
}
