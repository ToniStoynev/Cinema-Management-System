using CinemaManagementSystem.Domain.CinemasManagement.Exceptions;
using ModelConstants = CinemaManagementSystem.Domain.CinemasManagement.Models.ModelConstants;

namespace CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas
{
    using CinemaManagementSystem.Domain.Common.Models;
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
