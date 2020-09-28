using CinemaManagementSystem.Domain.CinemasManagment.Models.Cinemas;

namespace CinemaManagementSystem.Domain.CinemasManagment.Factories.Cinemas
{
    internal class CinemaFactory : ICinemaFactory
    {
        private string cinemaName = default!;
        private string address = default!;

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

        public Cinema Build() => new Cinema(this.cinemaName, this.address);

        public Cinema Build(string cinemaName, string addres)
            => this
            .WithName(cinemaName)
            .WithAddress(address)
            .Build();
    }
}
