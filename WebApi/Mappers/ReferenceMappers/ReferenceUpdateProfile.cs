using AutoMapper;
using DtoLayer.ReferenceDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.ReferenceMappers
{
    public class ReferenceUpdateProfile : Profile
    {
        public ReferenceUpdateProfile()
        {
            CreateMap<Reference, ReferenceUpdateDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Reference, ReferenceUpdateDto>().ReverseMap().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Reference, ReferenceUpdateDto>().ReverseMap().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<Reference, ReferenceUpdateDto>().ReverseMap().ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));
            CreateMap<Reference, ReferenceUpdateDto>().ReverseMap().ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));
        }
    }
}
