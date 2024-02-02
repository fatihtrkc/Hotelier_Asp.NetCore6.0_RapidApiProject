using AutoMapper;
using DtoLayer.ContactDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.ContactMappers
{
    public class ContactAddProfile : Profile
    {
        public ContactAddProfile() 
        {
            CreateMap<ContactAddDto, Contact>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<ContactAddDto, Contact>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<ContactAddDto, Contact>().ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));
            CreateMap<ContactAddDto, Contact>().ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));
        }
    }
}
