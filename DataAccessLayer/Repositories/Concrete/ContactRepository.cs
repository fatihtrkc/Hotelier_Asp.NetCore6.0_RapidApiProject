using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        private readonly HotelierAppContext db;
        public ContactRepository(HotelierAppContext db) : base(db)
        {
            this.db = db;
        }
    }
}
