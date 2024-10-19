using EventSourcingCQRS.Events;

namespace EventSourcingCQRS
{
    public class EventStore : IEventStore
    {
        private readonly EventStoreContext _context;

        public EventStore(EventStoreContext context)
        {
            _context = context;
        }

        public void Save(Event @event)
        {
            _context.Events.Add(@event);
            _context.SaveChanges();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Events.ToList();
        }
    }
}
