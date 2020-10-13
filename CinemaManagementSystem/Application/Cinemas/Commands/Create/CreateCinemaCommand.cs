namespace CinemaManagementSystem.Application.Cinemas.Commands.Create
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Identity;
    using Domain.CinemasManagement.Factories.Cinemas;


    public class CreateCinemaCommand : IRequest<CreateCinemaOutputModel>
    {
        public CreateCinemaCommand(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }

        public string Name { get; }

        public string Address { get; }

        public class CreateCinemaCommandHanlder : IRequestHandler<CreateCinemaCommand, CreateCinemaOutputModel>
        {
            private ICurrentUser currentUser;
            private ICinemaRepository cinemaRepository;
            private ICinemaFactory cinemaFactory;

            public CreateCinemaCommandHanlder(
                ICurrentUser currentUser,
                ICinemaRepository cinemaRepository,
                ICinemaFactory cinemaFactory)
            {
                this.currentUser = currentUser;
                this.cinemaRepository = cinemaRepository;
                this.cinemaFactory = cinemaFactory;
            }
            public async Task<CreateCinemaOutputModel> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
            {
                var userId = this.currentUser.UserId;

                var cinema = this.cinemaFactory
                    .WithName(request.Name)
                    .WithAddress(request.Address)
                    .Build();

                await this.cinemaRepository.Save(cinema, cancellationToken);

                return new CreateCinemaOutputModel(cinema.Id);
            }
        }
    }
}
