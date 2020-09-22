using System.Threading;
using System.Threading.Tasks;
using CinemaManagementSystem.Domain.Common;

namespace CinemaManagementSystem.Application.Common.Contracts
{
    public interface IRepository<in TEntity>
        where TEntity: IAggregateRoot
    {
        Task Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
