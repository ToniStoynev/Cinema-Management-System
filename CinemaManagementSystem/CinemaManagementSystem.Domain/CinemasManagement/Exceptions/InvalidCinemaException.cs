using CinemaManagementSystem.Domain.Common;

namespace CinemaManagementSystem.Domain.CinemasManagement.Exceptions
{
    public class InvalidCinemaException : BaseDomainException
    {
        public InvalidCinemaException()
        {

        }

        public InvalidCinemaException(string error) => this.Error = error;
    }
}
