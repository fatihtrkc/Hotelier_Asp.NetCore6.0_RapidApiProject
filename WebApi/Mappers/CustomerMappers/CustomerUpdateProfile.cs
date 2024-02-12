using AutoMapper;
using DtoLayer.CustomerDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.CustomerMappers
{
    public class CustomerUpdateProfile : Profile
    {
        public CustomerUpdateProfile() 
        {
            CreateMap<Customer, CustomerUpdateDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Customer, CustomerUpdateDto>().ReverseMap().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Customer, CustomerUpdateDto>().ReverseMap().ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));
            CreateMap<Customer, CustomerUpdateDto>().ReverseMap().ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City));
        }
    }
}
