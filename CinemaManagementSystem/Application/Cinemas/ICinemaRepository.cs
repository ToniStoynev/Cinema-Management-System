namespace CinemaManagementSystem.Application.Cinemas
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.CinemasManagement.Models.Cinemas;
    using System.Collections.Generic;
    using Queries.All;
    using Queries.Details;



    public interface ICinemaRepository : IRepository<Cinema>
    {
        Task<Cinema> Find(int id, CancellationToken cancellationToken = default);

        Task<CinemaDetailsOutputModel> GetDetailsById(int id, CancellationToken cancellationToken = default);


        Task<IEnumerable<CinemaListingModel>> AllCinemas(CancellationToken cancellationToken = default);

        Task<int> Total(CancellationToken cancellationToken = default);
    }
}
