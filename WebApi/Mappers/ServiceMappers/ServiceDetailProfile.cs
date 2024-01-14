using AutoMapper;
using DtoLayer.ServiceDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.ServiceMappers
{
    public class ServiceDetailProfile : Profile
    {
        public ServiceDetailProfile()
        {
            CreateMap<Service, ServiceDetailDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Service, ServiceDetailDto>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<Service, ServiceDetailDto>().ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon));
            CreateMap<Service, ServiceDetailDto>().ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
        }
    }
}
