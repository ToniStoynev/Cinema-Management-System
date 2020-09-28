using CinemaManagementSystem.Domain.CinemasManagment.Models.Cinemas;

namespace CinemaManagementSystem.Web.Features
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;


    [ApiController]
    public class CinemasController : ControllerBase
    {
        private  static readonly Cinema cinema = new Cinema("CinemaMax", "bul. Cherni vruh 21");

        [HttpGet]
        [Route("[controller]")]
        public IEnumerable<Room> GetAll()
            => cinema.Rooms.ToList();
    }
}
