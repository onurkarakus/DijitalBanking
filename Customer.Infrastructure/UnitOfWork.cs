using Customer.Domain.DataModels.Base;
using Customer.Domain.Interfaces.Respoistories.Base;
using Customer.Infrastructure.DbContextInformation;
using Customer.Infrastructure.Repositories.Base;
using System.Collections;

namespace Customer.Infrastructure
{
    public class UnitOfWork<TId> : IUnitOfWork<TId>
    {
        private readonly CustomerDbContext _dbContext;
        private bool disposed;
        private Hashtable _repositories;

        public UnitOfWork(CustomerDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IBaseRepository<TEntity, TId> Repository<TEntity>() where TEntity : AuditableEntity<TId>
        {
            return new BaseRepository<TEntity, TId>(_dbContext);
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CommitAndRemoveCacheAsync(CancellationToken cancellationToken, params string[] cacheKeys)
        {
            var result = await _dbContext.SaveChangesAsync(cancellationToken);

            return result;
        }

        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            disposed = true;
        }
    }
}
