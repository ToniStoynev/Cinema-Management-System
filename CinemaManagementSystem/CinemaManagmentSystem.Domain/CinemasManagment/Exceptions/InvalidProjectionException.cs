using CinemaManagementSystem.Domain.Common;

namespace CinemaManagementSystem.Domain.CinemasManagment.Exceptions
{
    public class InvalidProjectionException : BaseDomainException
    {
        public InvalidProjectionException()
        {

        }

        public InvalidProjectionException(string error) => this.Error = error; 
    }
}
