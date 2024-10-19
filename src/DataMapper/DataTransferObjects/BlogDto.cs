namespace DataMapper.DataTransferObjects
{
    public class BlogDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Guid CategoryId { get; set; }
    }

}
