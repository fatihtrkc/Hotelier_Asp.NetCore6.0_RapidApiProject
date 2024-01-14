using AutoMapper;
using DtoLayer.EmployeeDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.EmployeeMappers
{
    public class EmployeeDetailProfile : Profile
    {
        public EmployeeDetailProfile()
        {
            CreateMap<Employee, EmployeeDetailDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Employee, EmployeeDetailDto>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Employee, EmployeeDetailDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<Employee, EmployeeDetailDto>().ForMember(dest => dest.Facebook, opt => opt.MapFrom(src => src.Facebook));
            CreateMap<Employee, EmployeeDetailDto>().ForMember(dest => dest.Twitter, opt => opt.MapFrom(src => src.Twitter));
            CreateMap<Employee, EmployeeDetailDto>().ForMember(dest => dest.Instagram, opt => opt.MapFrom(src => src.Instagram));
            CreateMap<Employee, EmployeeDetailDto>().ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
        }
    }
}
