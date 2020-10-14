namespace CinemaManagementSystem.Application.Cinemas.Commands.AddProjection
{
    using  System;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using MediatR;
    using System.Linq;

    public class AddProjectionCommand : EntityCommand<int>, IRequest<Result>
    {
        public int RoomId { get; set; } = default!;
        public string Name { get; set; } = default!;

        public short DurationMinutes { get; set; } = default!;

        public string StartDate { get; set; } = default!;

        public int AvailableSeatsCount { get; set; } = default!;
        public class AddProjectionCommandHandler : IRequestHandler<AddProjectionCommand, Result>
        {
            private readonly ICinemaRepository cinemaRepository;

            public AddProjectionCommandHandler(ICinemaRepository cinemaRepository)
                => this.cinemaRepository = cinemaRepository;
            public async Task<Result> Handle(AddProjectionCommand request, CancellationToken cancellationToken)
            {
                var cinema = await this.cinemaRepository.Find(request.Id, cancellationToken);

                if (cinema == null)
                {
                    return "Cinema with given id does not exist";
                }

                var room =  cinema.Rooms.SingleOrDefault(r => r.Id == request.RoomId);

                if (room == null)
                {
                    return "Room with given id does not exist";
                }

                room.AddProjection(
                    request.Name, 
                    request.DurationMinutes, 
                    DateTime.Parse(request.StartDate), 
                    request.AvailableSeatsCount);

                await this.cinemaRepository.Save(cinema, cancellationToken);

                return Result.Success;
            }
        }
    }
}
