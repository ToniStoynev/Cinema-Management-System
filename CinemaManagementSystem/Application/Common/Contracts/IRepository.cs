namespace CinemaManagementSystem.Application.Common.Contracts
{
    using CinemaManagementSystem.Domain.Common;

    public interface IRepository<out TEntity>
        where TEntity: IAggregateRoot
    {
      
    }
}
