using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly HotelierAppContext db;
        //private readonly ILogger logger;
        public GenericRepository(HotelierAppContext db)
        {
            this.db = db;
            //this.logger = logger;
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                db.Entry<T>(entity).State = EntityState.Added;
                return true;
            }
            catch (Exception exception)
            {
                //logger.LogError(exception, exception.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                db.Entry<T>(entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception exception)
            {
                //logger.LogError(exception, exception.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                db.Entry<T>(entity).State = EntityState.Modified; 
                return true;
            }
            catch (Exception exception)
            {
                //logger.LogError(exception, exception.Message);
                return false;
            }
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entities = await db.Set<T>().FirstOrDefaultAsync(expression);
                //if (entities is null) logger.LogWarning("Entity is not found for expression.", expression);
                return entities;
            }
            catch (Exception exception)
            {
                //logger.LogError(exception, exception.Message);
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entities = await db.Set<T>().Where(expression).ToListAsync();
                //if (entities is null) logger.LogWarning("Entities are not found for expression.", expression);
                return entities;
            }
            catch (Exception exception)
            {
                //logger.LogError(exception, exception.Message);
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await db.Set<T>().ToListAsync();
            }
            catch (Exception exception)
            {
                //logger.LogError(exception, exception.Message);
                return null;
            }
        }
    }
}
