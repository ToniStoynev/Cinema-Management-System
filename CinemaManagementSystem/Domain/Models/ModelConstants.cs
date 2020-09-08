namespace CinemaManagementSystem.Domain.Models
{

    public class ModelConstants
    {
        public class Room
        {
            public const int MinRoomNumber = 1;
            public const int MaxRoomNumber = 20;

            public const short MinSeatsPerRow = 10;
            public const short MaxSeatsPerRow = 30;

            public const short MinRowsCount = 10;
            public const short MaxRowsCount = 30;
        }

        public class Projection
        {
            public const int MinAvailableSeatsCount = 0;
        }

        public class Movie
        {
            public const short MinMovieDuration = 60;
            public const short MaxMovieDuration = 240;
        }
        public class Ticket
        {
            public const double MinTicketPrice = 5.0;
            public const double MaxTicketPrice = 20.0;
        }
    }
}
