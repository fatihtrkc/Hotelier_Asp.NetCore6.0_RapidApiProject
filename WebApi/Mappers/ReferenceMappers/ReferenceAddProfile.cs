using AutoMapper;
using DtoLayer.ReferenceDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.ReferenceMappers
{
    public class ReferenceAddProfile : Profile
    {
        public ReferenceAddProfile()
        {
            CreateMap<ReferenceAddDto, Testimonial>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<ReferenceAddDto, Testimonial>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<ReferenceAddDto, Testimonial>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));
            CreateMap<ReferenceAddDto, Testimonial>().ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));
        }
    }
}
