using CinemaManagementSystem.Domain.CinemasManagment.Models.Cinemas;
using CinemaManagementSystem.Domain.Common;

namespace CinemaManagementSystem.Domain.CinemasManagment.Factories.Cinemas
{
    public interface ICinemaFactory : IFactory<Cinema>
    {
        ICinemaFactory WithName(string name);

        ICinemaFactory WithAddress(string address);
    }
}
