﻿using CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas;

namespace CinemaManagementSystem.Domain.Common.Models
{
    using FluentAssertions;
    using Xunit;
    public class EntitySpecs
    {
        [Fact]
        public void EntitiesWithEqualIdsShouldBeEqual()
        {
            // Arrange
                var first = new Cinema("First", "Sofia").SetId(1);
                var second = new Cinema("Second", "Varna").SetId(1);

                // Act
                var result = first == second;

                // Arrange
                result.Should().BeTrue();
        }

        [Fact]
        public void EntitiesWithDifferentIdsShouldNotBeEqual()
        {
            // Arrange
            var first = new Cinema("First", "Sofia").SetId(1);
            var second = new Cinema("Second", "Varna").SetId(2);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }

    internal static class EntityExtensions
    {

        public static TEntity SetId<TEntity>(this TEntity entity, int id)
            where TEntity : Entity<int>
            => (entity.SetId<int>(id) as TEntity)!;
        private static Entity<T> SetId<T>(this Entity<T> entity, int id)
            where T : struct
        {
            entity
                        .GetType()
                        .BaseType!
                    .GetProperty(nameof(Entity<T>.Id))!
                    .GetSetMethod(true)!
                .Invoke(entity, new object?[] { id });

            return entity;
        }
    }
}
