namespace CinemaManagementSystem.Infrastructure.Common.Persistence
{
    using Microsoft.EntityFrameworkCore;
    internal class CinemaManagementDbInitializer : IInitializer
    {
        private readonly CinemaManagementSystemDbContext db;

        public CinemaManagementDbInitializer(CinemaManagementSystemDbContext db)
            => this.db = db;

        public void Initialize()
            => this.db.Database.Migrate();
    }
}
