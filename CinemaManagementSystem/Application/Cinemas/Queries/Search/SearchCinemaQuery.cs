namespace CinemaManagementSystem.Application.Cinemas.Queries.Search
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    public class SearchCinemaQuery : IRequest<SearchCinemaOutputModel>
    {
        public class SearchCinemaQueryHandler : IRequestHandler<SearchCinemaQuery, SearchCinemaOutputModel>
        {
            private readonly ICinemaRepository cinemaRepository;

            public SearchCinemaQueryHandler(ICinemaRepository cinemaRepository)
                => this.cinemaRepository = cinemaRepository;
            public async Task<SearchCinemaOutputModel> Handle(SearchCinemaQuery request, 
                CancellationToken cancellationToken)
            {
                var cinemaListingModel = await this.cinemaRepository
                    .AllCinemas(cancellationToken);

                var totalCinemas = await cinemaRepository.Total(cancellationToken);

               return new SearchCinemaOutputModel(cinemaListingModel, totalCinemas);
            }
        }
    }
}
