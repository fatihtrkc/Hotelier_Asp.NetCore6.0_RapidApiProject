using AutoMapper;
using DtoLayer.CustomerDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.CustomerMappers
{
    public class CustomerAddProfile : Profile
    {
        public CustomerAddProfile() 
        {
            CreateMap<CustomerAddDto, Customer>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<CustomerAddDto, Customer>().ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));
            CreateMap<CustomerAddDto, Customer>().ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City));
        }
    }
}
