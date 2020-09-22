using CinemaManagementSystem.Domain.Cinemas.Models.Cinemas;
using CinemaManagementSystem.Domain.Common;

namespace CinemaManagementSystem.Domain.Cinemas.Factories.Cinemas
{
    public interface ICinemaFactory : IFactory<Cinema>
    {
        ICinemaFactory WithName(string name);

        ICinemaFactory WithAddress(string address);
    }
}
