using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        private readonly HotelierAppContext db;
        //private readonly ILogger logger;
        public ServiceRepository(HotelierAppContext db) : base(db)
        {
            this.db = db;
            //this.logger = logger;
        }
    }
}
