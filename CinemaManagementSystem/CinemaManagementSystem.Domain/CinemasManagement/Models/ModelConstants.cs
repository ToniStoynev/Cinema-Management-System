namespace CinemaManagementSystem.Domain.CinemasManagement.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinEmailLength = 5;
            public const int MaxEmailLength = 15;

            public const int MaxPassLength = 20;
        }

        public class Cinema
        {
            public const int MinCinemaName = 3;
            public const int MaxCinemaName = 15;

            public const int MinAddressName = 5;
            public const int MaxAddressName = 25;
        }

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
            public const int MaxAvailableSeatsCount = Room.MaxSeatsPerRow * Room.MaxRowsCount;

        }

        public class Movie
        {
            public const int MinMovieNameLength = 3;
            public const int MaxMovieNameLength = 30;

            public const short MinMovieDuration = 60;
            public const short MaxMovieDuration = 300;
        }
        public class Ticket
        {
            public const double MinTicketPrice = 5.0;
            public const double MaxTicketPrice = 20.0;
        }
    }
}
