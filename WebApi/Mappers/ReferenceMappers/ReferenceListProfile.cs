using AutoMapper;
using DtoLayer.ReferenceDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.ReferenceMappers
{
    public class ReferenceListProfile : Profile
    {
        public ReferenceListProfile()
        {
            CreateMap<Testimonial, ReferenceListDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Testimonial, ReferenceListDto>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Testimonial, ReferenceListDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<Testimonial, ReferenceListDto>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));
            CreateMap<Testimonial, ReferenceListDto>().ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));
            CreateMap<Testimonial, ReferenceListDto>().ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
        }
    }
}
