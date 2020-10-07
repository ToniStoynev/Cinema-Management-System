using CinemaManagementSystem.Domain.Common;

namespace CinemaManagementSystem.Domain.CinemasManagement.Exceptions
{
    public class InvalidRoomException : BaseDomainException
    {
        public InvalidRoomException()
        {

        }

        public InvalidRoomException(string error) => this.Error = error; 
    }
}
