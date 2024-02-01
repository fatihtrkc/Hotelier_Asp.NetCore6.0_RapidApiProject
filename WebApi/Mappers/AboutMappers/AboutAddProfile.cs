using AutoMapper;
using DtoLayer.AboutDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.AboutMappers
{
    public class AboutAddProfile : Profile
    {
        public AboutAddProfile() 
        {
            CreateMap<AboutAddDto, About>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<AboutAddDto, About>().ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));
            CreateMap<AboutAddDto, About>().ForMember(dest => dest.RoomCount, opt => opt.MapFrom(src => src.RoomCount));
            CreateMap<AboutAddDto, About>().ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.EmployeeCount));
            CreateMap<AboutAddDto, About>().ForMember(dest => dest.CustomerCount, opt => opt.MapFrom(src => src.CustomerCount));
        }
    }
}
