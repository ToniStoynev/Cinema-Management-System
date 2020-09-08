namespace CinemaManagementSystem.Domain.Exceptions
{
    public class InvalidRoomException : BaseDomainException
    {
        public InvalidRoomException()
        {

        }

        public InvalidRoomException(string error) => this.Error = error; 
    }
}
