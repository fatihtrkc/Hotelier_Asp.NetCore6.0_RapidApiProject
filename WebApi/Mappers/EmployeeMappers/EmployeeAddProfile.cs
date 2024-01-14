using AutoMapper;
using DtoLayer.EmployeeDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.EmployeeMappers
{
    public class EmployeeAddProfile : Profile
    {
        public EmployeeAddProfile()
        {
            CreateMap<EmployeeAddDto, Employee>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<EmployeeAddDto, Employee>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<EmployeeAddDto, Employee>().ForMember(dest => dest.Facebook, opt => opt.MapFrom(src => src.Facebook));
            CreateMap<EmployeeAddDto, Employee>().ForMember(dest => dest.Twitter, opt => opt.MapFrom(src => src.Twitter));
            CreateMap<EmployeeAddDto, Employee>().ForMember(dest => dest.Instagram, opt => opt.MapFrom(src => src.Instagram));
        }
    }
}
