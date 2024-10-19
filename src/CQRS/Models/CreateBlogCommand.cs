namespace CQRS.Models
{
    public class CreateBlogCommand
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public int CategoryId { get; set; }
    }

}
