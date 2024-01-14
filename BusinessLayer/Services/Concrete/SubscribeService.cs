using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using DtoLayer.SubscribeDtos;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Concrete
{
    public class SubscribeService : ISubscribeService
    {
        private readonly ISubscribeRepository subscribeRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public SubscribeService(ISubscribeRepository subscribeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.subscribeRepository = subscribeRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(SubscribeAddDto subscribeAddDto)
        {
            try
            {
                var subscribe = mapper.Map<Subscribe>(subscribeAddDto);
                bool isAdded = await subscribeRepository.AddAsync(subscribe);
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

        public async Task<bool> UpdateAsync(SubscribeUpdateDto subscribeUpdateDto)
        {
            try
            {
                var subscribe = await subscribeRepository.GetFirstOrDefaultAsync(s => s.Id == subscribeUpdateDto.Id);
                subscribe = mapper.Map<Subscribe>(subscribeUpdateDto);
                bool isUpdated = await subscribeRepository.UpdateAsync(subscribe);
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
