namespace EventSourcingCQRS.Events
{
    public class BlogUpdatedEvent : Event
    {
        public Guid BlogId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int CategoryId { get; set; }
    }
}
