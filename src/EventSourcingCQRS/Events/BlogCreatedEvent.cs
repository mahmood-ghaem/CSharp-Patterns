namespace EventSourcingCQRS.Events
{
    public class BlogCreatedEvent : Event
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Guid CategoryId { get; set; }
    }
}
