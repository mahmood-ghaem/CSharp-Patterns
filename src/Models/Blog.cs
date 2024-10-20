﻿namespace Models
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Guid CategoryId { get; set; }
        public BlogCategory? Category { get; set; }
    }
}
