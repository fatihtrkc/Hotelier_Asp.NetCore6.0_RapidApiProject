using AutoMapper;
using DtoLayer.EmployeeDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.EmployeeMappers
{
    public class EmployeeUpdateProfile : Profile
    {
        public EmployeeUpdateProfile()
        {
            CreateMap<Employee, EmployeeUpdateDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap().ForMember(dest => dest.Facebook, opt => opt.MapFrom(src => src.Facebook));
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap().ForMember(dest => dest.Twitter, opt => opt.MapFrom(src => src.Twitter));
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap().ForMember(dest => dest.Instagram, opt => opt.MapFrom(src => src.Instagram));
        }
    }
}
