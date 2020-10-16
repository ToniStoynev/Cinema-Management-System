namespace CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas
{
    using Common;
    using System;
    using System.Collections.Generic;

    internal class MovieData : IInitialData
    {
        public Type EntityType => typeof(Movie);

        public IEnumerable<object> GetData()
            => new List<Movie>
            {
                new Movie("Indiana Jones", 120),
                new Movie("Star Wars II", 260),
                new Movie("Spiderman", 180),
                new Movie("The Godfather", 200),
                new Movie("Fight Club", 120),
                new Movie("Pirates", 120),
                new Movie("Jungle", 110)

            };
    }
}
