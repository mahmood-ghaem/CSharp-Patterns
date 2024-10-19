namespace EventSourcingCQRS.Events
{
    public class BlogCategoryCreatedEvent : Event
    {
        public string? Name { get; set; }
    }

}
