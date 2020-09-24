﻿namespace CinemaManagementSystem.Domain.Cinemas.Models.Cinemas
{
    using System.Collections.Generic;
    using Exceptions;
    using CinemaManagementSystem.Domain.Common.Models;
    using static ModelConstants.Room;

    public class Room : Entity<int>
    {
        private readonly List<Projection> projections;

        internal Room(int number, short seatsPerRow, short rows)
        {
            this.Validate(number, seatsPerRow, rows);

            this.Number = number;
            this.SeatsPerRow = seatsPerRow;
            this.Rows = rows;
            this.projections = new List<Projection>();
        }

        public int Number { get; }

        public short SeatsPerRow { get; }

        public short Rows { get; }

        public IReadOnlyCollection<Projection> Projections => this.projections.AsReadOnly();

        public void AddProjection(Projection projection) => this.projections.Add(projection);

        private void Validate(int number, short seatsPerRow, short rows)
        {
            Guard.AgainstOutOfRange<InvalidRoomException>(
                rows,
                MinRowsCount,
                MaxRowsCount,
                nameof(this.Rows));

            Guard.AgainstOutOfRange<InvalidRoomException>(
                number,
                MinRoomNumber,
                MaxRoomNumber,
                nameof(this.Number));

            Guard.AgainstOutOfRange<InvalidRoomException>(
                seatsPerRow,
                MinSeatsPerRow,
                MaxSeatsPerRow,
                nameof(this.SeatsPerRow));
        }
    }
}
