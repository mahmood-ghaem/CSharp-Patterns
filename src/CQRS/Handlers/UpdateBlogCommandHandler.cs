using CQRS.Models;

namespace CQRS.Handlers
{
    public class UpdateBlogCommandHandler
    {
        private readonly BlogDbContext _context;

        public UpdateBlogCommandHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateBlogCommand command)
        {
            var blog = await _context.Blogs.FindAsync(command.Id);
            if (blog != null)
            {
                blog.Title = command.Title;
                blog.Content = command.Content;
                blog.CategoryId = command.CategoryId;
                await _context.SaveChangesAsync();
            }
        }
    }

}
