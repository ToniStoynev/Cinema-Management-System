using CinemaManagementSystem.Domain.CinemasManagment.Exceptions;
using CinemaManagementSystem.Domain.Common.Models;

namespace CinemaManagementSystem.Domain.CinemasManagment.Models.Cinemas
{
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
