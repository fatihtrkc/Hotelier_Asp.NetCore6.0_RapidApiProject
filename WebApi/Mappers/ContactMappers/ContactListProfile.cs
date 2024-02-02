using AutoMapper;
using DtoLayer.ContactDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.ContactMappers
{
    public class ContactListProfile : Profile
    {
        public ContactListProfile() 
        {
            CreateMap<Contact, ContactListDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Contact, ContactListDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Contact, ContactListDto>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<Contact, ContactListDto>().ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));
            CreateMap<Contact, ContactListDto>().ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));
            CreateMap<Contact, ContactListDto>().ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
        }
    }
}
