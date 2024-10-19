namespace CQRS.Models
{
    public class UpdateBlogCommand
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Guid CategoryId { get; set; }
    }

}
