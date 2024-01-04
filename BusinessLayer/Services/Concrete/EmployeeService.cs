using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork unitOfWork;
        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            this.employeeRepository = employeeRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Employee entity)
        {
            try
            {
                bool isAdded = await employeeRepository.AddAsync(entity);
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

        public async Task<bool> UpdateAsync(Employee entity)
        {
            try
            {
                bool isUpdated = await employeeRepository.UpdateAsync(entity);
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
