﻿using AutoMapper;
using DtoLayer.ReferenceDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.ReferenceMappers
{
    public class ReferenceDetailProfile : Profile
    {
        public ReferenceDetailProfile()
        {
            CreateMap<Reference, ReferenceDetailDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Reference, ReferenceDetailDto>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Reference, ReferenceDetailDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<Reference, ReferenceDetailDto>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));
            CreateMap<Reference, ReferenceDetailDto>().ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));
            CreateMap<Reference, ReferenceDetailDto>().ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
        }
    }
}
