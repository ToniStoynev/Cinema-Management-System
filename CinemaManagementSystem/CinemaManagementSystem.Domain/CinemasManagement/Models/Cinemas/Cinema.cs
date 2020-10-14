namespace CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas
{
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Common;
    using CinemaManagementSystem.Domain.Common.Models;
    public class Cinema : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Room> rooms;

        internal Cinema(string name, string address)
        {
            Validate(name, address);

            Name = name;
            Address = address;

            rooms = new HashSet<Room>();
        }
        public string Name { get; private set; }

        public string Address { get; private set; }

        public IReadOnlyCollection<Room> Rooms => rooms.ToList().AsReadOnly();

        public Cinema UpdateName(string name)
        {
            ValidateName(name);
            Name = name;

            return this;
        }

        public Cinema UpdateAddress(string address)
        {
            ValidateAddress(address);
            Address = address;

            return this;
        }

        public void AddNewRoom(int number, short seatsPerRow, short rows)
        {
            var room = new Room(number, seatsPerRow, rows);

            this.rooms.Add(room);
        }

        private void Validate(string name, string address)
        {
            ValidateName(name);
            ValidateAddress(address);
        }

        private void ValidateName(string name) =>
            Guard.AgainstEmptyStringException<InvalidCinemaException>(name, nameof(Name));

        private void ValidateAddress(string address) =>
            Guard.AgainstEmptyStringException<InvalidCinemaException>(address, nameof(Address));
    }
}
