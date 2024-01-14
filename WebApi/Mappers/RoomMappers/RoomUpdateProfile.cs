using AutoMapper;
using DtoLayer.RoomDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.RoomMappers
{
    public class RoomUpdateProfile : Profile
    {
        public RoomUpdateProfile()
        {
            CreateMap<Room, RoomUpdateDto>().ForMember(dest => dest.No, opt => opt.MapFrom(src => src.No));
            CreateMap<Room, RoomUpdateDto>().ReverseMap().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Room, RoomUpdateDto>().ReverseMap().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<Room, RoomUpdateDto>().ReverseMap().ForMember(dest => dest.CoverImage, opt => opt.MapFrom(src => src.CoverImage));
            CreateMap<Room, RoomUpdateDto>().ReverseMap().ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
            CreateMap<Room, RoomUpdateDto>().ReverseMap().ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
        }
    }
}
