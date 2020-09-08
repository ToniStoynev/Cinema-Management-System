namespace CinemaManagementSystem.Domain.Exceptions
{
    public class InvalidMovieException : BaseDomainException
    {
        public InvalidMovieException()
        {

        }

        public InvalidMovieException(string error) => this.Error = error;
    }
}
