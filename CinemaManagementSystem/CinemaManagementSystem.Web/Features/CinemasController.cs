namespace CinemaManagementSystem.Web.Features
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Application.Cinemas.Queries.Search;
    using Application.Cinemas.Commands.Create;
    using Microsoft.AspNetCore.Authorization;

    public class CinemasController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult<SearchCinemaOutputModel>> Get(
            [FromQuery] SearchCinemaQuery query)
            => await this.Send(query);

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<CreateCinemaOutputModel>> Create(
            CreateCinemaCommand command)
            => await this.Send(command);
    }
}
