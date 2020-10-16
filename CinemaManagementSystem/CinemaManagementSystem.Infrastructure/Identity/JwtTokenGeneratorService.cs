namespace CinemaManagementSystem.Infrastructure.Identity
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using CinemaManagementSystem.Application.Common;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    public class JwtTokenGeneratorService : IJwtTokenGenerator
    {
        private readonly ApplicationSettings applicationSettings;
        private readonly UserManager<User> userManager;

        public JwtTokenGeneratorService(IOptions<ApplicationSettings> applicationSettings, 
            UserManager<User> userManager)
        {
            this.applicationSettings = applicationSettings.Value;
            this.userManager = userManager;
        } 
        public async Task<string> GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.applicationSettings.Secret);

            var roles  = await this.userManager.GetRolesAsync(user);

            var claimList = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Email)
            };

            AddRolesToClaims(claimList, roles);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimList),

                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken((token));

            

            return encryptedToken;
        }

        private void AddRolesToClaims(List<Claim> claims, IEnumerable<string> roles)
        {
            foreach (var role in roles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, role);
                claims.Add(roleClaim);
            }
        }
    }
}
