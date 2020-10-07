using System;
using FakeItEasy;

namespace CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas
{
    public class ProjectionFakes : IDummyFactory
    {
        public bool CanCreate(Type type) => type == typeof(Projection);

        public object Create(Type type)
            => new Projection(new Movie("StarWars", 200),
                DateTime.Now.AddDays(1), 100);
        public Priority Priority => Priority.Default;
    }
}
