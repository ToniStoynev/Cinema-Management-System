namespace CinemaManagementSystem.Application.Cinemas.Queries.All
{
    using Common.Mapping;
    using Domain.CinemasManagement.Models.Cinemas;
    public class CinemaListingModel : IMapFrom<Cinema>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Address { get; private set; } = default!;
    }
}
