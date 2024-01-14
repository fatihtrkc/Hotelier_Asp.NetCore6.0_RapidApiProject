using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using DtoLayer.EmployeeDtos;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(EmployeeAddDto employeeAddDto)
        {
            try
            {
                var employee = mapper.Map<Employee>(employeeAddDto);
                bool isAdded = await employeeRepository.AddAsync(employee);
                if (isAdded) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Employee entity)
        {
            try
            {
                bool isDeleted = await employeeRepository.DeleteAsync(entity);
                if (isDeleted) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(EmployeeUpdateDto employeeUpdateDto)
        {
            try
            {
                var employee = mapper.Map<Employee>(employeeUpdateDto);
                bool isUpdated = await employeeRepository.UpdateAsync(employee);
                if (isUpdated) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Employee> GetFirstOrDefaultAsync(Expression<Func<Employee, bool>> expression)
        {
            try
            {
                return await employeeRepository.GetFirstOrDefaultAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllWhereAsync(Expression<Func<Employee, bool>> expression)
        {
            try
            {
                return await employeeRepository.GetAllWhereAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            try
            {
                return await employeeRepository.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
