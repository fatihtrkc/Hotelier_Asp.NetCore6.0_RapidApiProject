using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly HotelierAppContext db;
        //private readonly ILogger logger;
        public EmployeeRepository(HotelierAppContext db) : base(db)
        {
            this.db = db;
            //this.logger = logger;
        }
    }
}
