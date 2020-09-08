namespace CinemaManagementSystem.Domain.Exceptions
{
    public class InvalidTicketException : BaseDomainException
    {
        public InvalidTicketException()
        {

        }

        public InvalidTicketException(string error) => this.Error = error;
    }
}
