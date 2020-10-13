namespace CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas
{
    using Exceptions;
    using Common.Models;
    using static ModelConstants.Movie;
    public class Movie : Entity<int>
    {
        internal Movie(string name, short durationMinutes)
        {
            this.Validate(name, durationMinutes);

            this.Name = name;
            this.DurationMinutes = durationMinutes;
        }

        private Movie()
        {

            this.Name = default!;
            this.DurationMinutes = default!;
        }
        public string Name { get; }

        public short DurationMinutes { get; }

        private void Validate(string name, short durationMinutes)
        {
            Guard.AgainstEmptyStringException<InvalidMovieException>
                (name, 
                 nameof(this.Name));

            Guard.AgainstOutOfRange<InvalidMovieException>
                (durationMinutes, 
                 MinMovieDuration, 
                 MaxMovieDuration);
        }
    }
}
