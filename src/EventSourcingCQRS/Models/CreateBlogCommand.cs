namespace EventSourcingCQRS.Models
{
    public class CreateBlogCommand
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Guid CategoryId { get; set; }
    }

}
