using Customer.Domain.DataModels.Base;

namespace Customer.Domain.Interfaces.Respoistories.Base;

public interface IUnitOfWork<TId> : IDisposable
{
    IBaseRepository<T, TId> Repository<T>() where T : AuditableEntity<TId>;

    Task<int> CommitAsync(CancellationToken cancellationToken);

    Task<int> CommitAndRemoveCacheAsync(CancellationToken cancellationToken, params string[] cacheKeys);

    Task Rollback();
}
