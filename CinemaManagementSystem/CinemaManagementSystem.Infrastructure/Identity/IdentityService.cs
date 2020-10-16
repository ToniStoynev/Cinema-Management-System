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
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public IdentityService(UserManager<User> userManager, 
                IJwtTokenGenerator jwtTokenGenerator,
                RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.roleManager = roleManager;
        }
        public async Task<Result> Register(UserInputModel userInput)
        {
            var isRoot = !userManager.Users.Any();

            var user = new User(userInput.Email);

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            if (identityResult.Succeeded)
            {
                if (isRoot)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    await userManager.AddToRoleAsync(user, "User");

                }
            }

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

            var token = await this.jwtTokenGenerator.GenerateToken(user);

            return  new LoginOutputModel(token);
        }
    }
}
