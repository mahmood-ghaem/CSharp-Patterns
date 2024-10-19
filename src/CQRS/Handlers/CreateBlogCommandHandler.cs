using CQRS.Models;
using Models;

namespace CQRS.Handlers
{
    public class CreateBlogCommandHandler
    {
        private readonly BlogDbContext _context;

        public CreateBlogCommandHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateBlogCommand command)
        {
            var blog = new Blog
            {
                Title = command.Title,
                Content = command.Content,
                CategoryId = command.CategoryId
            };

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }
    }

}
