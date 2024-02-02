using AutoMapper;
using DtoLayer.ContactDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.ContactMappers
{
    public class ContactUpdateProfile : Profile
    {
        public ContactUpdateProfile() 
        {
            CreateMap<Contact, ContactUpdateDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Contact, ContactUpdateDto>().ReverseMap().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Contact, ContactUpdateDto>().ReverseMap().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<Contact, ContactUpdateDto>().ReverseMap().ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));
            CreateMap<Contact, ContactUpdateDto>().ReverseMap().ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));
        }
    }
}
