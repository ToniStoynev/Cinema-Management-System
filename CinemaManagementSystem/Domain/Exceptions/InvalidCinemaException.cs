namespace CinemaManagementSystem.Domain.Exceptions
{
    public class InvalidCinemaException : BaseDomainException
    {
        public InvalidCinemaException()
        {

        }

        public InvalidCinemaException(string error) => this.Error = error;
    }
}
