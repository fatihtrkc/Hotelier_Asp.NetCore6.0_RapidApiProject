using AutoMapper;
using DtoLayer.RoomDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.RoomMappers
{
    public class RoomListProfile : Profile
    {
        public RoomListProfile()
        {
            CreateMap<Room, RoomListDto>().ForMember(dest => dest.No, opt => opt.MapFrom(src => src.No));
            CreateMap<Room, RoomListDto>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Room, RoomListDto>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<Room, RoomListDto>().ForMember(dest => dest.CoverImage, opt => opt.MapFrom(src => src.CoverImage));
            CreateMap<Room, RoomListDto>().ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
            CreateMap<Room, RoomListDto>().ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
            CreateMap<Room, RoomListDto>().ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
        }
    }
}
