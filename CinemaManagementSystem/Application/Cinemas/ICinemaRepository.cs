using CinemaManagementSystem.Domain.CinemasManagment.Models.Cinemas;

namespace CinemaManagementSystem.Application.Cinemas
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;

    public interface ICinemaRepository : IRepository<Cinema>
    {
        Task<Cinema> Find(int id, CancellationToken cancellationToken = default);


    }
}
