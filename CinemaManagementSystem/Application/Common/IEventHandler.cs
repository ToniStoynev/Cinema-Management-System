namespace CinemaManagementSystem.Application.Common
{
    using System.Threading.Tasks;
    public interface IEventHandler<in TEvent>
    {
        Task Handle(TEvent domainEvent);
    }
}
