using System;
using CinemaManagementSystem.Domain.Cinemas.Exceptions;
using CinemaManagementSystem.Domain.Common.Models;

namespace CinemaManagementSystem.Domain.Cinemas.Models.Cinemas
{
    using static ModelConstants.Projection;
    public class Projection : Entity<int>
    {
        internal Projection(
            Room room, 
            Movie movie, 
            DateTime startDate, 
            int availableSeatsCount)
        {
            this.ValidateAvailableSeatsCount(availableSeatsCount);
            this.ValidateStartDate(startDate);

            this.Room = room;
            this.Movie = movie;
            this.StartDate = startDate;
            this.AvailableSeatsCount = availableSeatsCount;
        }
        public Room Room { get; private set; }

        public Movie Movie { get; private set; }

        public DateTime StartDate { get; private set; }

        public int AvailableSeatsCount { get; private set; }

        public Projection UpdateRoom(Room room)
        {
            this.Room = room;

            return this;
        }

        public Projection UpdateMovie(Movie movie)
        {
            this.Movie = movie;

            return this;
        }

        public Projection UpdateStartDate(DateTime startDate)
        {
            this.ValidateStartDate(startDate);

            this.StartDate = startDate;

            return this;
        }

        public Projection DecreaseAvailableSeatsCount(int seatsCount)
        {
            this.AvailableSeatsCount -= seatsCount;

            return this;
        }

        public Projection IncreaseAvailableSeatsCount(int seatsCount)
        {
            this.AvailableSeatsCount += seatsCount;

            return this;
        }

        private void ValidateAvailableSeatsCount(int availableSeatsCount)
            => Guard.AgainstOutOfRange<InvalidProjectionException>(
                    availableSeatsCount,
                    MinAvailableSeatsCount,
                    Room.Rows * Room.SeatsPerRow);

        private void ValidateStartDate(DateTime startDate)
          => Guard.AgainstInvalidDate<InvalidProjectionException>(
              startDate,
              nameof(this.StartDate));
    }
}
