using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Concrete
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;
        private readonly IUnitOfWork unitOfWork;
        public RoomService(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
        {
            this.roomRepository = roomRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Room entity)
        {
            try
            {
                bool isAdded = await roomRepository.AddAsync(entity);
                if (isAdded) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Room entity)
        {
            try
            {
                bool isDeleted = await roomRepository.DeleteAsync(entity);
                if (isDeleted) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Room entity)
        {
            try
            {
                bool isUpdated = await roomRepository.UpdateAsync(entity);
                if (isUpdated) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Room> GetFirstOrDefaultAsync(Expression<Func<Room, bool>> expression)
        {
            try
            {
                return await roomRepository.GetFirstOrDefaultAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Room>> GetAllWhereAsync(Expression<Func<Room, bool>> expression)
        {
            try
            {
                return await roomRepository.GetAllWhereAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            try
            {
                return await roomRepository.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
