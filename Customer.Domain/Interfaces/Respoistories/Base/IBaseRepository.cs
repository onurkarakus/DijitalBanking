using Customer.Domain.Interfaces.BaseEntity;
using System.Linq.Expressions;

namespace Customer.Domain.Interfaces.Respoistories.Base;

public interface IBaseRepository<T, in TId> where T : class, IEntity<TId>
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(TId id);
    Task<T> GetByIdNoTrackAsync(TId id);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteByIdAsync(TId id);
}
