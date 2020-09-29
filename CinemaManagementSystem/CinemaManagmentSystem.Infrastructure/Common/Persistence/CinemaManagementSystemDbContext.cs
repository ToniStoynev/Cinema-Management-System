namespace CinemaManagementSystem.Infrastructure.Common.Persistence
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using Domain.CinemasManagment.Models.Cinemas;
    using Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
