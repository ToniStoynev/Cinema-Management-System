using System;
using FakeItEasy;

namespace CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas
{
    public class MovieFakes : IDummyFactory
    {
        public bool CanCreate(Type type) => true;

        public object? Create(Type type)
            => new Movie("James Bond 007", 160);

        public Priority Priority => Priority.Default;
    }
}
