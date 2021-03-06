﻿using System;
using CinemaManagementSystem.Domain.CinemasManagement.Exceptions;
using FluentAssertions;
using Xunit;

namespace CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas
{
    public class CinemaSpecs
    {
        [Fact]
        public void UpdateNameShouldMutateCinemaName()
        {
            //Arange
            var cinema = new Cinema("Cinemax", "bul. Bulgaria");

            //Act
            cinema.UpdateName("3DImax");

            //Asser
            cinema.Name.Should().Be("3DImax");
        }

        [Fact]
        public void UpdateNameWithInvalidNameShouldThrowException()
        {
            //Arange
            var cinema = new Cinema("Cinemax", "bul. Bulgaria");

            //Act
            Action act = () => cinema.UpdateName("");

            //Asser
            act.Should().Throw<InvalidCinemaException>();
        }

        [Fact]
        public void UpdateAddressShouldMutateCinemaAddress()
        {
            //Arrange
            var cinema = new Cinema("Cinemax", "bul. Bulgaria");

            //Act
            cinema.UpdateAddress("bul. Maria Luiza");

            //Assert
            cinema.Address.Should().Be("bul. Maria Luiza");
        }

        [Fact]
        public void UpdateAddressWithInvalidAddressShouldThrowException()
        {
            //Arange
            var cinema = new Cinema("Cinemax", "bul. Bulgaria");

            //Act
            Action act = () => cinema.UpdateAddress("");

            //Asser
            act.Should().Throw<InvalidCinemaException>();
        }

    }
}
