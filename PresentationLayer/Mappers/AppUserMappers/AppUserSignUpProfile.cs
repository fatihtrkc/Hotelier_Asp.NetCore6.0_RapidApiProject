using AutoMapper;
using EntityLayer.Concrete;
using PresentationLayer.Models.ViewModels.AppUserVMs;

namespace PresentationLayer.Mappers.AppUserMappers
{
    public class AppUserSignUpProfile : Profile
    {
        public AppUserSignUpProfile()
        {
            CreateMap<AppUserSignUpVM, AppUser>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<AppUserSignUpVM, AppUser>().ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));
            CreateMap<AppUserSignUpVM, AppUser>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username));
            CreateMap<AppUserSignUpVM, AppUser>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
