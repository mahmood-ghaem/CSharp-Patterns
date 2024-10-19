namespace EventSourcingCQRS.Events
{
    public class BlogDeletedEvent : Event
    {
        public Guid BlogId { get; set; }
    }
}
