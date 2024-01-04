using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    public class SubscribeRepository : GenericRepository<Subscribe>, ISubscribeRepository
    {
        private readonly HotelierAppContext db;
        //private readonly ILogger logger;
        public SubscribeRepository(HotelierAppContext db) : base(db)
        {
            this.db = db;
            //this.logger = logger;
        }
    }
}
