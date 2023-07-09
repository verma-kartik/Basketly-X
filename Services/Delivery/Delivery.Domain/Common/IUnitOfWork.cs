namespace Delivery.Domain.Common;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));

}