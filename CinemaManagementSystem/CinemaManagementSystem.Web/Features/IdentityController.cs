namespace CinemaManagementSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Identity;
    using Application.Identity.Commands.LoginUser;
    using Microsoft.AspNetCore.Mvc;
    using Application.Identity.Commands.CreateUser;


    public class IdentityController : ApiController
    {
        private readonly IIdentity identity;

        public IdentityController(IIdentity identity) => this.identity = identity;

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(CreateUserCommand command)
            => await this.Send(command);

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginUserCommand command)
            => await this.Send(command);
    }
}
