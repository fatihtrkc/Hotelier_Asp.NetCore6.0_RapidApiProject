using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using DtoLayer.RoomDtos;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Concrete
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public RoomService(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.roomRepository = roomRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(RoomAddDto roomAddDto)
        {
            try
            {
                var room = mapper.Map<Room>(roomAddDto);
                bool isAdded = await roomRepository.AddAsync(room);
                if (isAdded) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Room room)
        {
            try
            {
                bool isDeleted = await roomRepository.DeleteAsync(room);
                if (isDeleted) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(RoomUpdateDto roomUpdateDto)
        {
            try
            {
                var room = mapper.Map<Room>(roomUpdateDto);
                bool isUpdated = await roomRepository.UpdateAsync(room);
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
