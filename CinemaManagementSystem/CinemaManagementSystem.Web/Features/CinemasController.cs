namespace CinemaManagementSystem.Web.Features
{
    using Application.Common.Contracts;
    using Domain.CinemasManagment.Models.Cinemas;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;



    [ApiController]
    [Route("[controller]")]
    public class CinemasController : ControllerBase
    {
        private readonly IRepository<Cinema> cinemas;

        public CinemasController(IRepository<Cinema> cinemas) => this.cinemas = cinemas;


        [HttpGet]
        public IEnumerable<Cinema> Get()
            => this.cinemas.All().ToList();
    }
}
