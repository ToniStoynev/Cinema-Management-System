namespace CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas
{
    using System.Collections.Generic;
    using CinemaManagementSystem.Domain.Common.Models;
    using Exceptions;
    using Common;
    using System;
    using static ModelConstants.Room;

    public class Room : Entity<int>, IAggregateRoot
    {
        private readonly List<Projection> projections;

        internal Room(int number, short seatsPerRow, short rows)
        {
            Validate(number, seatsPerRow, rows);

            Number = number;
            SeatsPerRow = seatsPerRow;
            Rows = rows;
            projections = new List<Projection>();
        }

        public int Number { get; }

        public short SeatsPerRow { get; }

        public short Rows { get; }

        public IReadOnlyCollection<Projection> Projections => projections.AsReadOnly();

        public void AddProjection(
                string name, 
                short durationMinutes,
                DateTime startDate,
                int availableSeatsCount)
        {
            var movie = new Movie(name, durationMinutes);

            var projection = new Projection(movie, startDate, availableSeatsCount);

            this.projections.Add(projection);
        }

        private void Validate(int number, short seatsPerRow, short rows)
        {
            Guard.AgainstOutOfRange<InvalidRoomException>(
                rows,
                MinRowsCount,
                MaxRowsCount,
                nameof(Rows));

            Guard.AgainstOutOfRange<InvalidRoomException>(
                number,
                MinRoomNumber,
                MaxRoomNumber,
                nameof(Number));

            Guard.AgainstOutOfRange<InvalidRoomException>(
                seatsPerRow,
                MinSeatsPerRow,
                MaxSeatsPerRow,
                nameof(SeatsPerRow));
        }
    }
}
