using CinemaManagementSystem.Domain.CinemasManagment.Models.Cinemas;

namespace CinemaManagementSystem.Infrastructure.Common.Persistence
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    internal class CinemaManagementSystemDbContext : DbContext
    {
        public CinemaManagementSystemDbContext(DbContextOptions<CinemaManagementSystemDbContext> options)
                : base(options)
        {
                   
        }

        public DbSet<Cinema> Cinemas { get; set; } = default!;

        public DbSet<Room> Rooms { get; set; } = default!;

        public DbSet<Projection> Projections { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
