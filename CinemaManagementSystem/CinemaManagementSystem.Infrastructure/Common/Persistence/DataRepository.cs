namespace CinemaManagementSystem.Infrastructure.Common.Persistence
{
    using System.Threading;
    using System.Threading.Tasks;
    using CinemaManagementSystem.Domain.Common;
    using System.Linq;
    using Application.Common.Contracts;

    internal abstract class DataRepository<TEntity> : IRepository<TEntity>
        where TEntity: class, IAggregateRoot
    {
        private readonly CinemaManagementSystemDbContext db;
        protected DataRepository(CinemaManagementSystemDbContext db) => this.db = db;

        protected IQueryable<TEntity> All() => this.db.Set<TEntity>();

        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.db.Update(entity);

            await this.db.SaveChangesAsync(cancellationToken);
        }

    }
}
