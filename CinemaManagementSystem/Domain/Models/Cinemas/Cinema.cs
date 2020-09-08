﻿namespace CinemaManagementSystem.Domain.Models.Cinemas
{
    using CinemaManagementSystem.Domain.Common;
    using CinemaManagementSystem.Domain.Exceptions;
    using System.Collections.Generic;
    using System.Linq;

    public class Cinema : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Room> rooms;

        internal Cinema(string name, string address)
        {
            this.Validate(name, address);

            this.Name = name;
            this.Address = address;

            this.rooms = new HashSet<Room>();
        }
        public string Name { get; private set; }

        public string Address { get; private set; }

        public IReadOnlyCollection<Room> Rooms => this.rooms.ToList().AsReadOnly();

        public Cinema UpdateName(string name)
        {
            this.ValidateName(name);
            this.Name = name;

            return this;
        }

        public Cinema UpdateAddress(string address)
        {
            this.ValidateAddress(address);
            this.Address = address;

            return this;
        }

        public void AddNewRoom(Room room) => this.rooms.Add(room);

        private void Validate(string name, string address)
        {
            this.ValidateName(name);
            this.ValidateAddress(address);
        }

        private void ValidateName(string name) =>
            Guard.AgainstEmptyStringException<InvalidCinemaException>(name, nameof(this.Name));

        private void ValidateAddress(string address) =>
            Guard.AgainstEmptyStringException<InvalidCinemaException>(address, nameof(this.Address));
    }
}
