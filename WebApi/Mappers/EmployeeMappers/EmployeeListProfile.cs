using AutoMapper;
using DtoLayer.EmployeeDtos;
using EntityLayer.Concrete;

namespace WebApi.Mappers.EmployeeMappers
{
    public class EmployeeListProfile : Profile
    {
        public EmployeeListProfile()
        {
            CreateMap<Employee, EmployeeListDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Employee, EmployeeListDto>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Employee, EmployeeListDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<Employee, EmployeeListDto>().ForMember(dest => dest.Facebook, opt => opt.MapFrom(src => src.Facebook));
            CreateMap<Employee, EmployeeListDto>().ForMember(dest => dest.Twitter, opt => opt.MapFrom(src => src.Twitter));
            CreateMap<Employee, EmployeeListDto>().ForMember(dest => dest.Instagram, opt => opt.MapFrom(src => src.Instagram));
            CreateMap<Employee, EmployeeListDto>().ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
        }
    }
}
