using AutoMapper;
using DtoLayer.SubscribeDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.SubscribeMappers
{
    public class SubscribeAddProfile : Profile
    {
        public SubscribeAddProfile()
        {
            CreateMap<SubscribeAddDto, Subscribe>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
