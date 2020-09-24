namespace CinemaManagementSystem.Domain.Cinemas.Models.Cinemas
{
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;
    using System;


    public class ProjectionSpecs
    {
        [Fact]
        public void DecreaseAvailableSeatsCountShouldDecreaseAvailableSeatsCount()
        {
            //Arrage
            var projection = new Projection(new Movie("StarWars", 200),
                DateTime.Now.AddDays(1), 100);

            //Act
            projection.DecreaseAvailableSeatsCount(10);

            //Assert
            projection.AvailableSeatsCount.Should().Be(90);
        }

        [Fact]
        public void UpdateMovieWithCorrectMovieShouldMutateMovie()
        {
            //Arrange
            var projection = new Projection(new Movie("StarWars", 200),
                DateTime.Now.AddDays(1), 100);
            var movie = A.Dummy<Movie>();

            //Act
            projection.UpdateMovie(movie);

            //Assert
            projection.Movie.Should().Be(movie);

        }
    }
}
