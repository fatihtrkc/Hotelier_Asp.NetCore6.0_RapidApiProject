using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Concrete
{
    public class SubscribeService : ISubscribeService
    {
        private readonly ISubscribeRepository subscribeRepository;
        private readonly IUnitOfWork unitOfWork;
        public SubscribeService(ISubscribeRepository subscribeRepository, IUnitOfWork unitOfWork)
        {
            this.subscribeRepository = subscribeRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Subscribe entity)
        {
            try
            {
                bool isAdded = await subscribeRepository.AddAsync(entity);
                if (isAdded) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Subscribe entity)
        {
            try
            {
                bool isDeleted = await subscribeRepository.DeleteAsync(entity);
                if (isDeleted) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Subscribe entity)
        {
            try
            {
                bool isUpdated = await subscribeRepository.UpdateAsync(entity);
                if (isUpdated) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Subscribe> GetFirstOrDefaultAsync(Expression<Func<Subscribe, bool>> expression)
        {
            try
            {
                return await subscribeRepository.GetFirstOrDefaultAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Subscribe>> GetAllWhereAsync(Expression<Func<Subscribe, bool>> expression)
        {
            try
            {
                return await subscribeRepository.GetAllWhereAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Subscribe>> GetAllAsync()
        {
            try
            {
                return await subscribeRepository.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
