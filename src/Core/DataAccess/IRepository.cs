using Core.Entity;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IRepository<T>
        where T : BaseEntity, new()
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);

        Task<bool> AddRangeAsync(List<T> entities);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<List<T>> GetAllAsync(bool tracking = true);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, bool tracking = true);
    }
}
