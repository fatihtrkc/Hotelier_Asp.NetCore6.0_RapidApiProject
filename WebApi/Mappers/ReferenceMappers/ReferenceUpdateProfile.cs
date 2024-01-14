using AutoMapper;
using DtoLayer.ReferenceDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.ReferenceMappers
{
    public class ReferenceUpdateProfile : Profile
    {
        public ReferenceUpdateProfile()
        {
            CreateMap<Testimonial, ReferenceUpdateDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Testimonial, ReferenceUpdateDto>().ReverseMap().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Testimonial, ReferenceUpdateDto>().ReverseMap().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<Testimonial, ReferenceUpdateDto>().ReverseMap().ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));
            CreateMap<Testimonial, ReferenceUpdateDto>().ReverseMap().ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));
        }
    }
}
