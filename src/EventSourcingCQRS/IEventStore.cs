using EventSourcingCQRS.Events;

namespace EventSourcingCQRS
{
    public interface IEventStore
    {
        void Save(Event @event);
        IEnumerable<Event> GetAllEvents();
    }
}
