using DtoLayer.EmployeeDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Services.Abstract
{
    public interface IEmployeeService : IGenericService<Employee, EmployeeAddDto, EmployeeUpdateDto>
    {
    }
}
