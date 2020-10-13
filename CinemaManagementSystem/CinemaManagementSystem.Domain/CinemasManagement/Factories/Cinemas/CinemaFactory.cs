namespace CinemaManagementSystem.Domain.CinemasManagement.Factories.Cinemas
{
    using System;
    using InnerFactories;
    using System.Collections.Generic;
    using CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas;

    internal class CinemaFactory : ICinemaFactory
    {
        private string cinemaName;
        private string address;
        private readonly List<Room> rooms;

        public CinemaFactory()
        {
            this.cinemaName = string.Empty;
            this.address = string.Empty;
            this.rooms = new List<Room>();
        }
        public ICinemaFactory WithName(string name)
        {
            this.cinemaName = name;
            return this;
        }
        public ICinemaFactory WithAddress(string address)
        {
            this.address = address;
            return this;
        }

        public ICinemaFactory WithRooms(Action<RoomFactory> room)
        {
            var roomFactory = new RoomFactory();

            room(roomFactory);

            this.rooms.Add(roomFactory.Build());

            return this;
        }

        public Cinema Build()
        {
            var cinema = new Cinema(this.cinemaName, this.address);

            this.rooms.ForEach(r => cinema.AddNewRoom(r));

            return cinema;
        }
    }
}
