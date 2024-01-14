using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    public class ReferenceRepository : GenericRepository<Testimonial>, IReferenceRepository
    {
        private readonly HotelierAppContext db;
        //private readonly ILogger logger;
        public ReferenceRepository(HotelierAppContext db) : base(db)
        {
            this.db = db;
            //this.logger = logger;
        }
    }
}
