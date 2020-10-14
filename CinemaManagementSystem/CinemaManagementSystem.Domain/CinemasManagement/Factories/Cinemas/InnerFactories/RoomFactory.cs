namespace CinemaManagementSystem.Domain.CinemasManagement.Factories.Cinemas.InnerFactories
{
    using System.Collections.Generic;
    using Models.Cinemas;
    using System;

    public class RoomFactory
    {
        private int number;
        private short seatsPerRow;
        private short rows;
        private readonly List<Projection> projections;

        internal RoomFactory()
        {
            this.number = default!;
            this.seatsPerRow = default!;
            this.rows = default!;
            this.projections = new List<Projection>();
        }

        public RoomFactory WithNumber(int number)
        {
            this.number = number;
            return this;
        }

        public RoomFactory WithSeatsPerRow(short seatsPerRow)
        {
            this.seatsPerRow = seatsPerRow;
            return this;
        }

        public RoomFactory WithRows(short rows)
        {
            this.rows = rows;
            return this;
        }

        public RoomFactory WithProjections(Action<ProjectionFactory> projection)
        {
            var projectionFactory = new ProjectionFactory();

            projection(projectionFactory);

            this.projections.Add(projectionFactory.Build());

            return this;
        }

        internal Room Build()
        {
            var room = new Room(this.number, this.seatsPerRow, this.rows);

           // this.projections.ForEach(p => room.AddProjection());

            return room;
        }
    }
}
