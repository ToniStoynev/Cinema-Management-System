using CinemaManagementSystem.Domain.Common;

namespace CinemaManagementSystem.Domain.CinemasManagment.Exceptions
{
    public class InvalidCinemaException : BaseDomainException
    {
        public InvalidCinemaException()
        {

        }

        public InvalidCinemaException(string error) => this.Error = error;
    }
}
