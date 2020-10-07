namespace CinemaManagementSystem.Infrastructure.Common.Events
{
    using System.Threading.Tasks;
    using CinemaManagementSystem.Domain.Common;
    public interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
