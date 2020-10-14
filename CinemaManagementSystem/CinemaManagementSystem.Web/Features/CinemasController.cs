using CinemaManagementSystem.Application.Cinemas.Commands.AddRoom;
using CinemaManagementSystem.Application.Common;

namespace CinemaManagementSystem.Web.Features
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Application.Cinemas.Queries.Search;
    using Application.Cinemas.Commands.Create;
    using Application.Cinemas.Queries.Details;

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
    }
}
