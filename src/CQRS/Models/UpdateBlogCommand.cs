namespace CQRS.Models
{
    public class UpdateBlogCommand
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int CategoryId { get; set; }
    }

}
