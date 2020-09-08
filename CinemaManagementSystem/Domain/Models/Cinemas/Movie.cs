namespace CinemaManagementSystem.Domain.Models.Cinemas
{
    using CinemaManagementSystem.Domain.Common;
    using CinemaManagementSystem.Domain.Exceptions;

    using static ModelConstants.Movie;
    public class Movie : ValueObject
    {
        internal Movie(string name, short durationMinutes)
        {
            this.Validate(name, durationMinutes);

            this.Name = name;
            this.DurationMinutes = durationMinutes;
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
