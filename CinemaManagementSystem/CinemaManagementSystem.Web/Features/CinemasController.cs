namespace CinemaManagementSystem.Web.Features
{
    using Application.Common.Contracts;
    using Domain.CinemasManagment.Models.Cinemas;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Application.Common;
    using Microsoft.Extensions.Options;




    [ApiController]
    [Route("[controller]")]
    public class CinemasController : ControllerBase
    {
        private readonly IRepository<Cinema> cinemas;
        private readonly IOptions<ApplicationSettings> settings;

        public CinemasController(IRepository<Cinema> cinemas, IOptions<ApplicationSettings> settings)
        {
            this.cinemas = cinemas;
            this.settings = settings;
        }


        [HttpGet]
        public object Get() => new 
        {
            Setting = this.settings,
            Cinemas = this.cinemas.All().ToList()
        };
    }
}
