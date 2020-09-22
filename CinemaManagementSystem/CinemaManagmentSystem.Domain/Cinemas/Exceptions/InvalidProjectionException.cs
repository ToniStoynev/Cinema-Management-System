using CinemaManagementSystem.Domain.Common;

namespace CinemaManagementSystem.Domain.Cinemas.Exceptions
{
    public class InvalidProjectionException : BaseDomainException
    {
        public InvalidProjectionException()
        {

        }

        public InvalidProjectionException(string error) => this.Error = error; 
    }
}
