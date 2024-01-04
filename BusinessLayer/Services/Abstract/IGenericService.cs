using EntityLayer.Abstract;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Abstract
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
