using System;
using CinemaManagementSystem.Domain.CinemasManagment.Exceptions;
using CinemaManagementSystem.Domain.Common.Models;

namespace CinemaManagementSystem.Domain.CinemasManagment.Models.Cinemas
{
    using static ModelConstants.Projection;
    using static  ModelConstants.Room;
    public class Projection : Entity<int>
    {
        internal Projection(
            Movie movie, 
            DateTime startDate, 
            int availableSeatsCount)
        {
            this.ValidateAvailableSeatsCount(availableSeatsCount);
            this.ValidateStartDate(startDate);

            this.Movie = movie;
            this.StartDate = startDate;
            this.AvailableSeatsCount = availableSeatsCount;
        }


        private Projection(DateTime startDate, int availableSeatsCount)
        {
            this.StartDate = startDate;
            this.AvailableSeatsCount = availableSeatsCount;

            this.Movie = default!;
        }

        public Movie Movie { get; private set; }

        public DateTime StartDate { get; private set; }

        public int AvailableSeatsCount { get; private set; }

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
                    MaxSeatsPerRow * MaxSeatsPerRow);

        private void ValidateStartDate(DateTime startDate)
          => Guard.AgainstInvalidDate<InvalidProjectionException>(
              startDate,
              nameof(this.StartDate));
    }
}
