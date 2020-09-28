using CinemaManagementSystem.Domain.Common;

namespace CinemaManagementSystem.Domain.CinemasManagment.Exceptions
{
    public class InvalidMovieException : BaseDomainException
    {
        public InvalidMovieException()
        {

        }

        public InvalidMovieException(string error) => this.Error = error;
    }
}
