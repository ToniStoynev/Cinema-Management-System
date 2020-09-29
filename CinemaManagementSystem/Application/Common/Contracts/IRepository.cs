namespace CinemaManagementSystem.Application.Common.Contracts
{
    using System.Threading;
    using System.Threading.Tasks;
    using CinemaManagementSystem.Domain.Common;
    using System.Linq;

    public interface IRepository<out TEntity>
        where TEntity: IAggregateRoot
    {
        IQueryable<TEntity> All();
        Task<int> SaveChanges(CancellationToken cancellationToken = default);
    }
}
