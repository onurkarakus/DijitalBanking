using DigitalBanking.Common.Interfaces.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DigitalBanking.Common.Interfaces.Respoistory;

public interface IBaseRepository<T, in TId, TContext>
    where TContext : DbContext
    where T : class, IEntity<TId>
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(TId id);
    Task<T> GetByIdNoTrackAsync(TId id);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<T> DeleteByIdAsync(TId id);
}
