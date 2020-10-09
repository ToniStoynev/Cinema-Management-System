namespace CinemaManagementSystem.Infrastructure.Cinemas.Repositories
{
    using Domain.CinemasManagement.Models.Cinemas;
    using Common.Persistence;
    using Application.Cinemas;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Collections.Generic;
    using Application.Cinemas.Queries.Search;

    internal class CinemaRepository : DataRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(CinemaManagementSystemDbContext db) : base(db)
        {
        }

        public async Task<Cinema> Find(int id, CancellationToken cancellationToken = default)
        {
            return All()
                .FirstOrDefault(x => x.Id == id)! ;
        }

        public async Task<IEnumerable<CinemaListingModel>> AllCinemas(CancellationToken cancellationToken = default)
        {
            return await
                this.All()
                    .Select(cinema => new CinemaListingModel(
                        cinema.Id,
                        cinema.Name,
                        cinema.Address))
                    .ToListAsync(cancellationToken);
        }

        public async Task<int> Total(CancellationToken cancellationToken = default)
        {
            return await 
                this.All().CountAsync(cancellationToken);
        }

      
    }
}
