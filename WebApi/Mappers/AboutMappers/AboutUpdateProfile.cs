using AutoMapper;
using DtoLayer.AboutDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.AboutMappers
{
    public class AboutUpdateProfile : Profile
    {
        public AboutUpdateProfile() 
        {
            CreateMap<AboutUpdateDto, About>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<AboutUpdateDto, About>().ReverseMap().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<AboutUpdateDto, About>().ReverseMap().ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));
            CreateMap<AboutUpdateDto, About>().ReverseMap().ForMember(dest => dest.CustomerCount, opt => opt.MapFrom(src => src.CustomerCount));
            CreateMap<AboutUpdateDto, About>().ReverseMap().ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.EmployeeCount));
            CreateMap<AboutUpdateDto, About>().ReverseMap().ForMember(dest => dest.RoomCount, opt => opt.MapFrom(src => src.RoomCount));
        }
    }
}
