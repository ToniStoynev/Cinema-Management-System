namespace CinemaManagementSystem.Domain.CinemasManagement.Factories.Cinemas
{
    using Models.Cinemas;
    using System;
    using Common;
    using InnerFactories;


    public interface ICinemaFactory : IFactory<Cinema>
    {
        ICinemaFactory WithName(string name);

        ICinemaFactory WithAddress(string address);

        ICinemaFactory WithRooms(Action<RoomFactory> room);
    }
}
