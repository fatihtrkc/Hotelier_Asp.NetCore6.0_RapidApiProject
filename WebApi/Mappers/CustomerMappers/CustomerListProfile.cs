using AutoMapper;
using DtoLayer.CustomerDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.CustomerMappers
{
    public class CustomerListProfile : Profile
    {
        public CustomerListProfile() 
        {
            CreateMap<Customer, CustomerListDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Customer, CustomerListDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Customer, CustomerListDto>().ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));
            CreateMap<Customer, CustomerListDto>().ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City));
            CreateMap<Customer, CustomerListDto>().ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
        }
    }
}
