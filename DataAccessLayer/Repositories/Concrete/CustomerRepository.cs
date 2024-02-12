using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly HotelierAppContext db;
        public CustomerRepository(HotelierAppContext db) : base(db)
        {
            this.db = db;
        }
    }
}
