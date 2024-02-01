using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly HotelierAppContext db;
        public BookingRepository(HotelierAppContext db) : base(db)
        {
            this.db = db;
        }
    }
}
