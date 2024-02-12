using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using DtoLayer.BookingDtos;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Concrete
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public BookingService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.bookingRepository = bookingRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(BookingAddDto bookingAddDto)
        {
            try
            {
                var booking = mapper.Map<Booking>(bookingAddDto);
                bool isAdded = await bookingRepository.AddAsync(booking);
                if (isAdded) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Booking booking)
        {
            try
            {
                bool isDeleted = await bookingRepository.DeleteAsync(booking);
                if (isDeleted) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(BookingUpdateDto bookingUpdateDto)
        {
            try
            {
                var booking = mapper.Map<Booking>(bookingUpdateDto);
                bool isUpdated = await bookingRepository.UpdateAsync(booking);
                if (isUpdated) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Booking> GetFirstOrDefaultAsync(Expression<Func<Booking, bool>> expression)
        {
            try
            {
                return await bookingRepository.GetFirstOrDefaultAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Booking>> GetAllWhereAsync(Expression<Func<Booking, bool>> expression)
        {
            try
            {
                return await bookingRepository.GetAllWhereAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            try
            {
                return await bookingRepository.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
