using CinemaManagementSystem.Domain.CinemasManagement.Exceptions;
using CinemaManagementSystem.Domain.Common.Models;

namespace CinemaManagementSystem.Domain.CinemasManagement.Models.Reservations
{
    using static ModelConstants.Ticket;
    public class Ticket : Entity<int>
    {
        internal Ticket(double price)
        {
            this.ValidatePrice(price);
            this.Price = price;
        }
        public double Price { get; private set; }

        private void ValidatePrice(double price)
            => Guard.AgainstOutOfRange<InvalidTicketException>(
                    price,
                    MinTicketPrice,
                    MaxTicketPrice,
                    nameof(this.Price));
    }
}
