using AutoMapper;
using DtoLayer.ServiceDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.ServiceMappers
{
    public class ServiceListProfile : Profile
    {
        public ServiceListProfile()
        {
            CreateMap<Service, ServiceListDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Service, ServiceListDto>().ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon));
            CreateMap<Service, ServiceListDto>().ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
        }
    }
}
