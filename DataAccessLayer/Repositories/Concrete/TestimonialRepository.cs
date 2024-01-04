using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    public class TestimonialRepository : GenericRepository<Testimonial>, ITestimonialRepository
    {
        private readonly HotelierAppContext db;
        //private readonly ILogger logger;
        public TestimonialRepository(HotelierAppContext db) : base(db)
        {
            this.db = db;
            //this.logger = logger;
        }
    }
}
