namespace CinemaManagementSystem.Domain.CinemasManagement.Factories.Cinemas.InnerFactories
{
    using CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas;

    public class MovieFactory
    {
        private string name;
        private short durationMinutes;

        internal MovieFactory()
        {
            this.name = string.Empty;
            this.durationMinutes = 0;
        }

        public MovieFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

        public MovieFactory WithDurationMinutes(short durationMinutes)
        {
            this.durationMinutes = durationMinutes;
            return this;
        }

        internal Movie Build()
            => new Movie(this.name, this.durationMinutes);

    }
}
