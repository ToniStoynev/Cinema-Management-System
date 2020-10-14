namespace CinemaManagementSystem.Application.Cinemas.Commands.AddRoom
{
    using Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddRoomCommand : EntityCommand<int>, IRequest<Result>
    {
        public int Number { get; set; } = default!;

        public short SeatsPerRow { get; set; } = default!;

        public short Rows { get; set; } = default!;

        public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand, Result>
        {
            private readonly ICinemaRepository cinemaRepository;

            public AddRoomCommandHandler(ICinemaRepository cinemaRepository)
                => this.cinemaRepository = cinemaRepository;
            public async Task<Result> Handle(AddRoomCommand request, CancellationToken cancellationToken)
            {
                var cinema = await this.cinemaRepository.Find(request.Id, cancellationToken);

                if (cinema == null)
                {
                    return "Cinema with given id does not exist!";
                }

                cinema.AddNewRoom(request.Number, request.SeatsPerRow, request.Rows);

                await this.cinemaRepository.Save(cinema, cancellationToken);

                return Result.Success;
            }
        }

    }
}
