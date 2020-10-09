namespace CinemaManagementSystem.Web.Features
{

    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Application.Cinemas.Queries.Search;


    [ApiController]
    [Route("[controller]")]
    public class CinemasController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult<SearchCinemaOutputModel>> Get(
            [FromQuery] SearchCinemaQuery query)
            => await this.Send(query);
    }
}
