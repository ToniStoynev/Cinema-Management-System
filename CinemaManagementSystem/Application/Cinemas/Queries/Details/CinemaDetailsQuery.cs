namespace CinemaManagementSystem.Application.Cinemas.Queries.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;


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
                var cinema = await cinemaRepository.Find(request.Id, cancellationToken);

                return new CinemaDetailsOutputModel(cinema.Name, cinema.Address);
            }
        }
    }
}
