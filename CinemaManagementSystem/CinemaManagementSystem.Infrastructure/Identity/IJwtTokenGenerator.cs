namespace CinemaManagementSystem.Infrastructure.Identity
{
    using System.Threading.Tasks;

    public interface IJwtTokenGenerator
    {
       Task<string> GenerateToken(User user);
    }
}
