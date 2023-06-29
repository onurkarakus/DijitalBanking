using DigitalBanking.Common.DataModels;
using DigitalBanking.Common.Interfaces.Respoistory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DigitalBanking.Common.Repositories;

public class BaseRepository<T, TId, TContext> : IBaseRepository<T, TId, TContext>
    where T : AuditableEntity<TId>
    where TContext : DbContext
{
    private readonly TContext dbContext;
    protected DbSet<T> table;

    public BaseRepository(TContext dbContext)
    {
        this.dbContext = dbContext;
        table = dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await dbContext.Set<T>().AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        if (entity.GetType().GetProperty("IsDelete") != null)
        {
            T _entity = entity;

            _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

            UpdateAsync(_entity);
        }
        else
        {
            var dbEntityEntry = dbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                table.Attach(entity);
                table.Remove(entity);
            }
        }

        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<T> DeleteByIdAsync(TId id)
    {
        var entity = await GetByIdAsync(id);

        if (entity == null)
        {
            return entity;
        }
        else
        {
            if (entity.GetType().GetProperty("IsDelete") != null)
            {
                T _entity = entity;
                _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

                await UpdateAsync(_entity);
            }
            else
            {
                await DeleteAsync(entity);
            }
        }

        await dbContext.SaveChangesAsync();

        return entity;
    }

    public Task<T> GetAsync(Expression<Func<T, bool>> predicate) => table.Where(predicate).FirstOrDefaultAsync();

    public Task<List<T>> GetAllAsync() => dbContext.Set<T>().ToListAsync();

    public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate) => table.Where(predicate).ToListAsync();

    public async Task<T> GetByIdAsync(TId id) => await table.FindAsync(id);

    public async Task<T> GetByIdNoTrackAsync(TId id)
    {
        var entity = await table.FindAsync(id);
        dbContext.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public async Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize) => await dbContext.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();

    public async Task<T> UpdateAsync(T entity)
    {
        T exist = dbContext.Set<T>().Find(entity.Id);
        dbContext.Entry(exist).CurrentValues.SetValues(entity);

        await dbContext.SaveChangesAsync();

        return entity;
    }
}
