namespace CinemaManagementSystem.Infrastructure.Cinemas.Configuration
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.CinemasManagement.Models.Cinemas;
    using Microsoft.EntityFrameworkCore;
    internal  class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Name)
                .IsRequired();

            builder
                .Property(m => m.DurationMinutes)
                .IsRequired();
        }
    }
}
