namespace CinemaManagementSystem.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    public class User : IdentityUser
    {
        internal User(string email)
            => this.Email = email;
    }
}
