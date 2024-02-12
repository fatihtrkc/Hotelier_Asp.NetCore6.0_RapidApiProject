using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using DtoLayer.CustomerDtos;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(CustomerAddDto customerAddDto)
        {
            try
            {
                var about = mapper.Map<Customer>(customerAddDto);
                bool isAdded = await customerRepository.AddAsync(about);
                if (isAdded) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Customer customer)
        {
            try
            {
                bool isDeleted = await customerRepository.DeleteAsync(customer);
                if (isDeleted) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(CustomerUpdateDto customerUpdateDto)
        {
            try
            {
                var about = mapper.Map<Customer>(customerUpdateDto);
                bool isUpdated = await customerRepository.UpdateAsync(about);
                if (isUpdated) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Customer> GetFirstOrDefaultAsync(Expression<Func<Customer, bool>> expression)
        {
            try
            {
                return await customerRepository.GetFirstOrDefaultAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllWhereAsync(Expression<Func<Customer, bool>> expression)
        {
            try
            {
                return await customerRepository.GetAllWhereAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            try
            {
                return await customerRepository.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
