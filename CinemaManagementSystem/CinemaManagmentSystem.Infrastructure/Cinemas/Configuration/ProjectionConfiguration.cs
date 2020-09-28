using CinemaManagementSystem.Domain.CinemasManagment.Models.Cinemas;

namespace CinemaManagementSystem.Infrastructure.Cinemas.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class ProjectionConfiguration : IEntityTypeConfiguration<Projection>
    {
        public void Configure(EntityTypeBuilder<Projection> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.StartDate)
                .IsRequired();

            builder
                .Property(p => p.AvailableSeatsCount)
                .IsRequired();

            builder
                .OwnsOne(p => p.Movie, 
                    m =>
                {
                    m.WithOwner();

                    m.Property(mv => mv.Name);
                    m.Property(mv => mv.DurationMinutes);
                });
        }
    }
}
