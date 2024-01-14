using EntityLayer.Abstract;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Abstract
{
    public interface IGenericService<T, EntityAddDto, EntityUpdateDto> where T : BaseEntity where EntityAddDto : class where EntityUpdateDto : class
    {
        Task<bool> AddAsync(EntityAddDto entityAddDto);
        Task<bool> DeleteAsync(T entity);
        Task<bool> UpdateAsync(EntityUpdateDto entityUpdateDto);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
