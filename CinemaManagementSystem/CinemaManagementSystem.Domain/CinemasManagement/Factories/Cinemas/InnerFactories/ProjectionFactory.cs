namespace CinemaManagementSystem.Domain.CinemasManagement.Factories.Cinemas.InnerFactories
{
    using System;
    using CinemasManagement.Models.Cinemas;
    public class ProjectionFactory
    {
        private Movie movie;
        private DateTime startDate;
        private int availableSeatsCount;

        internal ProjectionFactory()
        {
            this.movie = default!;
            this.startDate = default!;
            this.availableSeatsCount = default!;
        }

        public ProjectionFactory WithMovie(Movie movie)
        {
            this.movie = movie;
            return this;
        }

        public ProjectionFactory WithStartDate(DateTime startDate)
        {
            this.startDate = startDate;
            return this;
        }

        public ProjectionFactory WithAvailableSeatsCount(int availableSeatsCount)
        {
            this.availableSeatsCount = availableSeatsCount;
            return this;
        }

        internal  Projection Build()
            => new Projection(this.movie, this.startDate, this.availableSeatsCount);
    }
}
