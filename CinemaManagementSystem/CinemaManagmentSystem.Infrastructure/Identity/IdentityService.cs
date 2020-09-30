namespace CinemaManagementSystem.Infrastructure.Identity
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Identity;
    using Application.Identity.Commands;
    using Application.Identity.Commands.LoginUser;
    using Microsoft.AspNetCore.Identity;

    public class IdentityService : IIdentity
    {
        private const string InvalidLoginErrorMessage = "Invalid credentials";

        private readonly UserManager<User> userManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public IdentityService(UserManager<User> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<Result> Register(UserInputModel userInput)
        {
            var user = new User(userInput.Email);

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors); 
        }

        public async Task<Result<LoginOutputModel>> Login(UserInputModel inputModel)
        {
            var user = await this.userManager.FindByEmailAsync(inputModel.Email);
            if (user == null)
            {
                return InvalidLoginErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, inputModel.Password);

            if (!passwordValid)
            {
                return InvalidLoginErrorMessage;
            }

            var token = this.jwtTokenGenerator.GenerateToken(user);

            return new LoginOutputModel(token);
        }
    }
}
