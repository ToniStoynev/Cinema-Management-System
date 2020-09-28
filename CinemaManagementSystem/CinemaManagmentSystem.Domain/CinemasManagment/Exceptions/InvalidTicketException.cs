using CinemaManagementSystem.Domain.Common;

namespace CinemaManagementSystem.Domain.CinemasManagment.Exceptions
{
    public class InvalidTicketException : BaseDomainException
    {
        public InvalidTicketException()
        {

        }

        public InvalidTicketException(string error) => this.Error = error;
    }
}
