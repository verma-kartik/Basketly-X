namespace Delivery.Domain.Common;

public interface IRepository<T> where T : IAggregate
{
    IUnitOfWork unitOfWork { get; }
}