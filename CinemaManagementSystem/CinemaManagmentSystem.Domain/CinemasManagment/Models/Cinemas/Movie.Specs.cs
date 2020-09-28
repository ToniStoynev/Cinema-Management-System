using System;
using CinemaManagementSystem.Domain.CinemasManagment.Exceptions;
using FluentAssertions;
using Xunit;

namespace CinemaManagementSystem.Domain.CinemasManagment.Models.Cinemas
{
    public class MovieSpecs
    {
        [Fact]
        public void ValidMovieShouldNotThrowException()
        {
            //Act
            Action act = () => new Movie("Valid movie", 120);

            //Assert
            act.Should().NotThrow<InvalidMovieException>();
        }

        [Fact]
        public void MovieWithInvalidNameShouldThrowException()
        {
            //Act
            Action act = () => new Movie("", 123);

            //Assert
            act.Should().Throw<InvalidMovieException>();
        }

        [Fact]
        public void MovieWithInvalidDurationShouldThrowException()
        {
            //Act
            Action act = () => new Movie("Valid movie", 12);

            //Assert
            act.Should().Throw<InvalidMovieException>();
        }
    }
}
