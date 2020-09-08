namespace CinemaManagementSystem.Domain.Exceptions
{
    public class InvalidProjectionException : BaseDomainException
    {
        public InvalidProjectionException()
        {

        }

        public InvalidProjectionException(string error) => this.Error = error; 
    }
}
