using AutoMapper;
using DtoLayer.ContactDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.ContactMappers
{
    public class ContactDetailProfile : Profile
    {
        public ContactDetailProfile() 
        {
            CreateMap<Contact, ContactDetailDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Contact, ContactDetailDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Contact, ContactDetailDto>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<Contact, ContactDetailDto>().ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));
            CreateMap<Contact, ContactDetailDto>().ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));
            CreateMap<Contact, ContactDetailDto>().ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
        }
    }
}
