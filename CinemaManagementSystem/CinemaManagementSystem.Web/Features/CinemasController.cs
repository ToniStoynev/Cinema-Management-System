using CinemaManagementSystem.Application.Cinemas.Commands.UpdateCinema;

namespace CinemaManagementSystem.Web.Features
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Application.Cinemas.Queries.All;
    using Application.Cinemas.Commands.Create;
    using Application.Cinemas.Queries.Details;
    using Application.Cinemas.Commands.AddProjection;
    using Application.Cinemas.Commands.AddRoom;
    using Application.Common;

    using Microsoft.AspNetCore.Authorization;

    public class CinemasController : ApiController
    {

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<ActionResult<SearchCinemaOutputModel>> GetAll(
            [FromQuery] SearchCinemaQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(nameof(Details) + PathSeparator + Id)]
        public async Task<ActionResult<CinemaDetailsOutputModel>> Details(
            [FromRoute] CinemaDetailsQuery query)
            => await this.Send(query);

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<CreateCinemaOutputModel>> Create(
            CreateCinemaCommand command)
            => await this.Send(command);

        [HttpPost]
        [Route(nameof(AddRoom) + PathSeparator + Id)]
        public async Task<ActionResult> AddRoom(
            int id, AddRoomCommand command)
            => await this.Send(command.SetId(id));

        [HttpPost]
        [Route(nameof(Edit) + PathSeparator + Id)]
        public async Task<ActionResult> Edit(int id, UpdateCinemaCommand command)
            => await this.Send(command.SetId(id));

        [HttpPost]
        [Route(nameof(AddProjection) + PathSeparator + Id)]
        public async Task<ActionResult> AddProjection(int id,  AddProjectionCommand command)
            => await this.Send(command.SetId(id));
    }
}
