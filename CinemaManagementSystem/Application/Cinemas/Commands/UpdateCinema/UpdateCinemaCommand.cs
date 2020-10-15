using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CinemaManagementSystem.Application.Common;
using MediatR;

namespace CinemaManagementSystem.Application.Cinemas.Commands.UpdateCinema
{
    public class UpdateCinemaCommand : EntityCommand<int>, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string Address { get; set; } = default!;

        public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand, Result>
        {
            private readonly ICinemaRepository cinemaRepository;

            public UpdateCinemaCommandHandler(ICinemaRepository cinemaRepository)
                => this.cinemaRepository = cinemaRepository;
            public async Task<Result> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
            {
                var cinema = await this.cinemaRepository.Find(request.Id, cancellationToken);

                if (cinema == null)
                {
                    return "Cinema with given id does not exist!";
                }

                cinema.UpdateName(request.Name);
                cinema.UpdateAddress(request.Address);

                await this.cinemaRepository.Save(cinema, cancellationToken);

                return Result.Success;
            }
        }
    }
}
