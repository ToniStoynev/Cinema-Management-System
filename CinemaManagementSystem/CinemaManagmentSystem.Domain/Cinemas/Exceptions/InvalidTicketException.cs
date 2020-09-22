using CinemaManagementSystem.Domain.Common;

namespace CinemaManagementSystem.Domain.Cinemas.Exceptions
{
    public class InvalidTicketException : BaseDomainException
    {
        public InvalidTicketException()
        {

        }

        public InvalidTicketException(string error) => this.Error = error;
    }
}
