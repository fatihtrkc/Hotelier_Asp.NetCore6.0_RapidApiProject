using DataAccessLayer.Context;
using DataAccessLayer.UnitOfWork.Abstract;

namespace DataAccessLayer.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly HotelierAppContext db;
        public UnitOfWork(HotelierAppContext db)
        {
            this.db = db;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await db.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
        }
    }
}
