using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        private readonly HotelierAppContext db;
        //private readonly ILogger logger;
        public RoomRepository(HotelierAppContext db) : base(db)
        {
            this.db = db;
            //this.logger = logger;
        }
    }
}
