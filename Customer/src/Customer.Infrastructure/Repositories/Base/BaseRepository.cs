using Customer.Domain.DataModels.Base;
using Customer.Domain.Interfaces.Respoistories.Base;
using Customer.Infrastructure.DbContextInformation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Customer.Infrastructure.Repositories.Base;

public class BaseRepository<T, TId> : IBaseRepository<T, TId> where T : AuditableEntity<TId>
{
    private readonly CustomerDbContext dbContext;
    protected DbSet<T> table;

    public BaseRepository(CustomerDbContext dbContext)
    {
        this.dbContext = dbContext;
        table = dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await dbContext.Set<T>().AddAsync(entity, cancellationToken);

        return entity;
    }

    public Task DeleteAsync(T entity)
    {
        if (entity.GetType().GetProperty("IsDelete") != null)
        {
            T _entity = entity;

            _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

            this.UpdateAsync(_entity);
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

        return Task.CompletedTask;
    }

    public Task DeleteByIdAsync(TId id)
    {
        var entity = GetByIdAsync(id);
        if (entity == null)
        {
            return Task.FromException(new ArgumentNullException(nameof(entity), $"Entity with Id value {id} can not be null."));
        }
        else
        {
            if (entity.GetType().GetProperty("IsDelete") != null)
            {
                T _entity = entity.Result;
                _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

                this.UpdateAsync(_entity);
            }
            else
            {
                DeleteAsync(entity.Result);
            }
        }

        return Task.CompletedTask;
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

    public Task UpdateAsync(T entity)
    {
        T exist = dbContext.Set<T>().Find(entity.Id);
        dbContext.Entry(exist).CurrentValues.SetValues(entity);

        return Task.CompletedTask;
    }
}
