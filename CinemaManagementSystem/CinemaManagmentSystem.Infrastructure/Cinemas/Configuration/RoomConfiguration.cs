using CinemaManagementSystem.Domain.CinemasManagment.Models.Cinemas;

namespace CinemaManagementSystem.Infrastructure.Cinemas.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .Property(r => r.Number)
                .IsRequired();

            builder
                .Property(r => r.SeatsPerRow)
                .IsRequired();

            builder
                .Property(r => r.Rows)
                .IsRequired();

            builder
                .HasMany(r => r.Projections)
                .WithOne();
        }
    }
}
