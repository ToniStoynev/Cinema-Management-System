namespace CinemaManagementSystem.Infrastructure.Cinemas.Repositories
{
    using Domain.CinemasManagement.Models.Cinemas;
    using Common.Persistence;
    using Application.Cinemas;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using System.Collections.Generic;
    using Application.Cinemas.Queries.All;
    using Application.Cinemas.Queries.Details;
    using System.Linq;


    internal class CinemaRepository : DataRepository<Cinema>, ICinemaRepository
    {
        private readonly IMapper mapper;

        public CinemaRepository(CinemaManagementSystemDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;
        public async Task<Cinema> Find(int id, CancellationToken cancellationToken = default)
        {
            return await this
                .All()
                .Include(c => c.Rooms)
                .FirstOrDefaultAsync(cinema => cinema.Id == id, cancellationToken);
        }

        public async Task<CinemaDetailsOutputModel> GetDetailsById(int id, CancellationToken cancellationToken = default)
        {
            return await this.mapper
                .ProjectTo<CinemaDetailsOutputModel>(this.All()
                    .Where(c => c.Id == id))
                    .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<CinemaListingModel>> AllCinemas(CancellationToken cancellationToken = default)
        {
            var query = this.All();

            return await this.mapper
                .ProjectTo<CinemaListingModel>(query)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> Total(CancellationToken cancellationToken = default)
        {
            return await 
                this.All().CountAsync(cancellationToken);
        }

    }
}
