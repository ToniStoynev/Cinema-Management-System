namespace CinemaManagementSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Identity;
    using Application.Identity.Commands;
    using Application.Identity.Commands.LoginUser;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentity identity;

        public IdentityController(IIdentity identity) => this.identity = identity;

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(UserInputModel model)
        {
            var result = await identity.Register(model);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(UserInputModel model)
        {
            var result = await identity.Login(model);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return result.Data;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(User.Identity.Name);
        }
    }
}
