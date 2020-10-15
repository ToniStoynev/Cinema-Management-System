namespace CinemaManagementSystem.Application.Cinemas.Queries.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.CinemasManagement.Specifications.Cinemas;

    public class CinemaDetailsQuery : IRequest<CinemaDetailsOutputModel>
    {
        public int Id { get; set; }
        public class CinemaDetailsQueryHandler : IRequestHandler<CinemaDetailsQuery, CinemaDetailsOutputModel>
        {
            private readonly ICinemaRepository cinemaRepository;

            public CinemaDetailsQueryHandler(ICinemaRepository cinemaRepository)
                => this.cinemaRepository = cinemaRepository;

            public async Task<CinemaDetailsOutputModel> Handle(CinemaDetailsQuery request, CancellationToken cancellationToken)
            {
                return await cinemaRepository.GetDetailsById(request.Id, cancellationToken);
            }
        }
    }
}
