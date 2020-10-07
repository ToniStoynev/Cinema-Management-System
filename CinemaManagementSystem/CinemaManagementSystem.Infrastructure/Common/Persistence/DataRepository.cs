namespace CinemaManagementSystem.Infrastructure.Common.Persistence
{
    using System.Threading;
    using System.Threading.Tasks;
    using CinemaManagementSystem.Domain.Common;
    using System.Linq;
    using Application.Common.Contracts;


    internal class DataRepository<TEntity> : IRepository<TEntity>
        where TEntity: class, IAggregateRoot
    {
        private readonly CinemaManagementSystemDbContext db;
        public DataRepository(CinemaManagementSystemDbContext db) => this.db = db;

        public IQueryable<TEntity> All() => this.db.Set<TEntity>();

        public  Task<int> SaveChanges(CancellationToken cancellationToken = default)
            => this.db.SaveChangesAsync(cancellationToken);

    }
}
