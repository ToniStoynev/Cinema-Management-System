namespace CinemaManagementSystem.Infrastructure.Common.Persistence
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas;

    internal class CinemaManagementSystemDbContext : IdentityDbContext<User>
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
