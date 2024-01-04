using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Concrete
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository serviceRepository;
        private readonly IUnitOfWork unitOfWork;
        public ServiceService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            this.serviceRepository = serviceRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Service entity)
        {
            try
            {
                bool isAdded = await serviceRepository.AddAsync(entity);
                if (isAdded) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Service entity)
        {
            try
            {
                bool isDeleted = await serviceRepository.DeleteAsync(entity);
                if (isDeleted) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Service entity)
        {
            try
            {
                bool isUpdated = await serviceRepository.UpdateAsync(entity);
                if (isUpdated) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Service> GetFirstOrDefaultAsync(Expression<Func<Service, bool>> expression)
        {
            try
            {
                return await serviceRepository.GetFirstOrDefaultAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Service>> GetAllWhereAsync(Expression<Func<Service, bool>> expression)
        {
            try
            {
                return await serviceRepository.GetAllWhereAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            try
            {
                return await serviceRepository.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
