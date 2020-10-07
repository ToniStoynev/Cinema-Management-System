using CinemaManagementSystem.Domain.CinemasManagement.Exceptions;
using ModelConstants = CinemaManagementSystem.Domain.CinemasManagement.Models.ModelConstants;

namespace CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas
{
    using System.Collections.Generic;
    using CinemaManagementSystem.Domain.Common.Models;
    using static ModelConstants.Room;

    public class Room : Entity<int>
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

        public void AddProjection(Projection projection) => projections.Add(projection);

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
