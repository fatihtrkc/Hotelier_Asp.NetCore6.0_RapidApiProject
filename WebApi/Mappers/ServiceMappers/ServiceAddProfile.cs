using AutoMapper;
using DtoLayer.ServiceDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.ServiceMappers
{
    public class ServiceAddProfile : Profile
    {
        public ServiceAddProfile()
        {
            CreateMap<ServiceAddDto, Service>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<ServiceAddDto, Service>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<ServiceAddDto, Service>().ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon));
        }
    }
}
