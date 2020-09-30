namespace CinemaManagementSystem.Application.Identity
{
    using System.Threading.Tasks;
    using Common;
    using Commands;
    using Commands.LoginUser;
    public interface IIdentity
    {
        Task<Result> Register(UserInputModel userInput);

        Task<Result<LoginOutputModel>> Login(UserInputModel inputModel);
    }
}
