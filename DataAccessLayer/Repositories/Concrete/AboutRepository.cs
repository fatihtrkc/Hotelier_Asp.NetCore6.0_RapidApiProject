using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        private readonly HotelierAppContext db;
        public AboutRepository(HotelierAppContext db) : base(db)
        {
            this.db = db;
        }
    }
}
