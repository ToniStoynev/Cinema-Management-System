using CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas;

namespace CinemaManagementSystem.Infrastructure.Cinemas.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class  CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(p => p.Name)
                .IsRequired();

            builder
                .Property(p => p.Address)
                .IsRequired();

            builder
                .HasMany(c => c.Rooms)
                .WithOne();
        }
    }
}
