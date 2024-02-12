using AutoMapper;
using DtoLayer.CustomerDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.CustomerMappers
{
    public class CustomerDetailProfile : Profile
    {
        public CustomerDetailProfile() 
        {
            CreateMap<Customer, CustomerDetailDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Customer, CustomerDetailDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Customer, CustomerDetailDto>().ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));
            CreateMap<Customer, CustomerDetailDto>().ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City));
            CreateMap<Customer, CustomerDetailDto>().ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
        }
    }
}
