namespace EventSourcingCQRS.Events
{
    public abstract class Event
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
