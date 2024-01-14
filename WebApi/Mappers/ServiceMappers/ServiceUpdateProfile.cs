using AutoMapper;
using DtoLayer.ServiceDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.ServiceMappers
{
    public class ServiceUpdateProfile : Profile
    {
        public ServiceUpdateProfile()
        {
            CreateMap<Service, ServiceUpdateDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Service, ServiceUpdateDto>().ReverseMap().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<Service, ServiceUpdateDto>().ReverseMap().ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon));
        }
    }
}
